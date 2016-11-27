--(f) Inserir um aluguer com inserção de um cliente com dados completos;
USE AEnima;
IF OBJECT_ID('dbo.InserirAluguerComNovoCliente') IS NOT NULL 
	DROP PROCEDURE dbo.InserirAluguerComNovoCliente

GO


CREATE FUNCTION GetPromocao(@pid INTEGER, @eqId INTEGER) RETURNS TABLE
AS
	RETURN (SELECT p.pId, p.inicio, p.fim, p.descr
		FROM Equipamento eq INNER JOIN Tipo t ON (eq.tipo = t.nome)
			INNER JOIN TipoPromocao tp ON (tp.tipo = t.nome)
			INNER JOIN Promocao p ON (p.pId = tp.pId)
		WHERE eq.eqId = @eqId AND p.pId = @pid)

GO
CREATE FUNCTION GetPromocaoTemporal (@pid INTEGER, @eqId INTEGER) RETURNS TIME
AS 
	BEGIN
	DECLARE @tempo TIME = NULL
	SELECT @tempo = tempoExtra FROM GetPromocao(@pid, @eqId) prom 
		INNER JOIN PromocaoTemporal pt ON(prom.pId = pt.pId)
		WHERE @pid = pt.pId;
	RETURN @tempo
	END
GO
CREATE FUNCTION GetPromocaoDesconto(@pid INTEGER, @eqId INTEGER) RETURNS FLOAT
AS 
		BEGIN
	DECLARE @desconto FLOAT = NULL
	SELECT @desconto = percentagemDesconto FROM GetPromocao(@pid, @eqId) prom 
		INNER JOIN PromocaoDesconto pd ON(prom.pId = pd.pId)
		WHERE @pid = pd.pId;
	RETURN @desconto
	END
GO

CREATE FUNCTION CalcularDuracaoPreco(@pid INT, @eqId INT, @preco FLOAT, @duracao TIME) 
RETURNS @moddedValues TABLE (preco FLOAT, duracao TIME)
AS BEGIN 
	--TODO: SET TRANSACTION LEVEL
	BEGIN TRAN
	DECLARE @precoComDesconto FLOAT, @desconto FLOAT, @tempoFinal TIME, @tempoExtra TIME
	SELECT @desconto = IsNull(percentagemDesconto, 0) FROM Equipamento eq 
			INNER JOIN Tipo t ON (t.nome = eq.tipo)
			INNER JOIN TipoPromocao tp ON (tp.tipo = t.nome)
			INNER JOIN Promocao p ON(p.pId = tp.pId)
			INNER JOIN PromocaoDesconto pd ON(pd.pId = p.pId)
		WHERE @pid = p.pId AND @eqId = eq.eqId;
	
	SELECT @tempoExtra = IsNull(tempoExtra, '00:00:00') FROM Equipamento eq 
			INNER JOIN Tipo t ON (t.nome = eq.tipo)
			INNER JOIN TipoPromocao tp ON (tp.tipo = t.nome)
			INNER JOIN Promocao p ON(p.pId = tp.pId)
			INNER JOIN PromocaoTemporal pd ON(pd.pId = p.pId)
		WHERE @pid = p.pId AND @eqId = eq.eqId 

	SET @precoComDesconto = @preco - (@preco * @desconto)
	SET @tempoFinal = @duracao + @tempoExtra

	INSERT INTO @moddedValues VALUES (@precoComDesconto, @tempoFinal)
	COMMIT
	RETURN
END

GO
CREATE PROCEDURE dbo.InserirAluguerComNovoCliente
	@empregado INT, 
	@cliente INT, 
	@eqId INT,
	@inicioAluguer DATETIME, 
	@duracao TIME,
	@preco FLOAT,
	@pid INT = NULL -- cliente escolhe de antemão qual a promoção que quer
AS 
	IF NOT EXISTS(SELECT * FROM Cliente WHERE cId = @cliente)
		THROW 50020, 'O Cliente inserido não existe.', 1;
	--VERIFICAR SE EQUIPAMENTO EXISTE
	IF NOT EXISTS(SELECT * FROM Equipamento WHERE eqId = @eqId)
		THROW 50021, 'O Equipamento inserido não existe.', 1;
	--VERIFICAR SE EMPREGADO EXISTE
	IF NOT EXISTS(SELECT * FROM Empregado WHERE eId = @empregado)
		THROW 50022, 'O Empregado inserido não existe.', 1;
		
	--VERIFICAR SE PREÇO EXISTE
	DECLARE @precoValidade DATE
	IF NOT EXISTS (SELECT validade = @precoValidade 
		FROM Equipamento eq INNER JOIN Tipo t ON(eq.tipo = t.nome)
							INNER JOIN Preco p ON(t.nome = p.tipo)
		WHERE p.valor = @preco AND p.duracao = @duracao AND eq.eqId = @eqId) 
		THROW 50022, 'Este preço é invalido para este produto inserido não existe.', 1;
	
	--VERIFICAR SE O PREÇO É VALIDO PARA O ALUGUER
	IF(@precoValidade < @inicioAluguer)
		THROW 50023, 'Data de validade para este preço é menor que a data do Aluguer', 1;
	

	DECLARE @desconto FLOAT, @tempoExtra TIME
	IF(@pid IS NOT NULL)
		BEGIN 
			IF EXISTS(SELECT * FROM GetPromocao(@pid, @eqId))
			BEGIN
				SET @desconto = GetPromocaoDesconto(@pid, @eqId)
				SET @tempoExtra = GetPromocaoTemporal(@pid, @eqId)
			END				
		END

	INSERT INTO Aluguer(eqId, empregado, cliente, data_inicio)
		VALUES(@eqId, @empregado, @cliente, @inicioAluguer)
	
GO

