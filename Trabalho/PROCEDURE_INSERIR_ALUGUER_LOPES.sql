--(g) Inserir um aluguer usando um cliente existente;
USE AEnima;
IF OBJECT_ID('dbo.InserirAluguer') IS NOT NULL 
	DROP PROCEDURE dbo.InserirAluguer
IF OBJECT_ID('dbo.InserirAluguerComNovoCliente') IS NOT NULL 
	DROP PROCEDURE dbo.InserirAluguerComNovoCliente 

GO
--INSERE UM ALUGUER COM CLIENTE ESPECIFICADO
CREATE PROCEDURE dbo.InserirAluguer
	@empregado INT, 
	@cliente INT = 0, 
	@eqId INT,
	@inicioAluguer DATETIME, 
	@duracao TIME,
	@preco FLOAT,
	@pid INT = NULL -- cliente escolhe de antemão qual a promoção que quer
AS 
	BEGIN TRAN -- 5 Reads, 3 Write
	--VERIFICAR SE O CLIENTE EXISTE
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
		WHERE p.valor = @preco AND p.duracao = @duracao AND eq.eqId = @eqId AND p.validade > @inicioAluguer) 
		THROW 50022, 'Este preço é invalido para este produto inserido não existe.', 1;


	DECLARE @duracaoFinal TIME, @precoFinal FLOAT
	IF(@pid IS NOT NULL)
	BEGIN
		IF EXISTS(SELECT * FROM Equipamento eq 
				INNER JOIN Tipo t ON (eq.tipo = t.nome)
				INNER JOIN TipoPromocao tp ON(t.nome = tp.tipo)
				INNER JOIN Promocao p ON(tp.pId = p.pId)
				WHERE @pid = p.pId AND p.inicio < @inicioAluguer AND  @inicioAluguer < p.fim)
			SELECT  @precoFinal = preco, @duracaoFinal = duracao 
				FROM CalcularDuracaoPreco(@pid, @eqId, @preco, @duracao) 
		ELSE THROW 50023, 'Esta promoção é invalida para este aluguer.', 1;
	END


	DECLARE @currentAluguer TABLE (id INT)
	DECLARE @currentAluguerId INT 
	INSERT INTO Aluguer(eqId, empregado, cliente, data_inicio)
		OUTPUT INSERTED.serial INTO @currentAluguer
		VALUES(@eqId, @empregado, @cliente, @inicioAluguer)

	SELECT @currentAluguerId = id FROM @currentAluguer
	INSERT INTO AluguerPrecoDuracao VALUES (@currentAluguerId, @duracaoFinal, @precoFinal)
	
	DECLARE @fimAluguer DATETIME = @inicioAluguer + CAST(@duracaoFinal AS DATETIME)
	INSERT INTO AluguerDataFim VALUES (@currentAluguerId, @fimAluguer)
	COMMIT

GO
--INSERE UM ALUGUER E UM CLIENTE NOVO
CREATE PROCEDURE dbo.InserirAluguerComNovoCliente 
	@cliente_nif INT,
	@cliente_nome VARCHAR(31),
	@cliente_morada VARCHAR(100), 
	@empregado INT, 
	@eqId INT,
	@inicioAluguer DATETIME, 
	@duracao TIME,
	@preco FLOAT,
	@pid INT = NULL -- cliente escolhe de antemão qual a promoção que quer
AS 
	DECLARE @idCliente INT = 0
	exec dbo.InserirCliente @cliente_nome, @cliente_nif, @cliente_morada, @idCliente
	exec dbo.InserirAluguer @empregado, @idCliente, @eqId, @inicioAluguer, @duracao, @preco, @pid
