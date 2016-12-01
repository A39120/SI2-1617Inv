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
	@cliente INT = 1, 
	@eqId INT,
	@inicioAluguer DATETIME, 
	@duracao TIME,
	@preco FLOAT,
	@pid INT = NULL -- cliente escolhe de antemão qual a promoção que quer
AS 
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	BEGIN TRAN -- 5 Reads, 3 Write
	--VERIFICAR SE O CLIENTE EXISTE
	IF NOT EXISTS(SELECT * FROM Cliente WHERE cId = @cliente)
		BEGIN
			ROLLBACK TRAN;
			THROW 50100, 'O cliente especificado não existe', 1;
		END
	--VERIFICAR SE EQUIPAMENTO EXISTE
	IF NOT EXISTS(SELECT * FROM dbo.EquipamentoDisponivel WHERE eqId = @eqId)
		BEGIN
			ROLLBACK TRAN;
			THROW 50101, 'O Equipamento inserido não existe', 1;
		END
	--VERIFICAR SE EMPREGADO EXISTE
	IF NOT EXISTS(SELECT * FROM Empregado WHERE eId = @empregado)
		BEGIN
			ROLLBACK TRAN;
			THROW 50102, 'O Empregado inserido não existe', 1;
		END
	--VERIFICAR SE PREÇO EXISTE
	IF NOT EXISTS (SELECT * FROM EquipamentoDisponivel eq INNER JOIN Preco p ON(eq.tipo = p.tipo)
		WHERE p.valor = @preco AND p.duracao = @duracao AND eq.eqId = @eqId AND p.validade > @inicioAluguer) 
		BEGIN
			ROLLBACK TRAN; 
			THROW 50103, 'Este preço e duração não constam na tabela de preços para este tipo.', 1;
		END

	DECLARE @duracaoFinal TIME, @precoFinal FLOAT
	IF(@pid IS NOT NULL)
		BEGIN
			IF EXISTS(SELECT * FROM EquipamentoDisponivel eq 
					INNER JOIN Tipo t ON (eq.tipo = t.nome)
					INNER JOIN TipoPromocao tp ON(t.nome = tp.tipo)
					INNER JOIN Promocao p ON(tp.pId = p.pId)
					WHERE @pid = p.pId AND p.inicio < @inicioAluguer AND  @inicioAluguer < p.fim)
				SELECT  @precoFinal = preco, @duracaoFinal = duracao 
					FROM CalcularDuracaoPreco(@pid, @eqId, @preco, @duracao) 
			ELSE 
				BEGIN
					ROLLBACK TRAN;
					THROW 50104,'Esta promoção é invalida para este aluguer.', 1
				END
		END
	ELSE 
		BEGIN 
			SET @duracaoFinal = @duracao 
			SET @precoFinal = @preco
		END
	DECLARE @currentAluguer TABLE (id VARCHAR(36))
	DECLARE @currentAluguerId VARCHAR(36)
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
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	BEGIN TRAN
	DECLARE @idCliente INT = 0
	exec dbo.InserirCliente @cliente_nome, @cliente_nif, @cliente_morada, @idCliente OUTPUT
	exec dbo.InserirAluguer @empregado, @idCliente, @eqId, @inicioAluguer, @duracao, @preco, @pid
	COMMIT