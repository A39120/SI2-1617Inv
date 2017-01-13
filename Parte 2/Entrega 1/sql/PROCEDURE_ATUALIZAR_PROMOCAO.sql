USE AEnima
IF OBJECT_ID('dbo.ActualizarPromocao') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarPromocao
IF OBJECT_ID('dbo.ActualizarPromocaoTemporal') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarPromocaoTemporal
IF OBJECT_ID('dbo.ActualizarPromocaoDesconto') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarPromocaoDesconto

GO
CREATE PROCEDURE dbo.ActualizarPromocao 
	@promotion_id INT, 
	@inicio DATETIME = NULL,
	@fim DATETIME = NULL,
	@descr VARCHAR(255) = NULL
AS 
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN -- 1 leitura e 1 escrita vs 3 escritas
	DECLARE @customInicio DATETIME, @customFim DATETIME, @customDesc VARCHAR(255)
	SELECT @customInicio=inicio, @customFim=fim, @customDesc = descr 
		FROM Promocao
		WHERE pId = @promotion_id
	IF(@inicio IS NOT NULL)  SET @customInicio = @inicio
	IF(@fim IS NOT NULL)  SET @customFim = @fim
	IF(@descr IS NOT NULL) SET @customDesc = @descr
	UPDATE Promocao 
		SET inicio = @customInicio,
			fim = @customFim, 
			descr = @customDesc
		WHERE pId = @promotion_id
	COMMIT

GO
CREATE PROCEDURE dbo.ActualizarPromocaoTemporal 
	@promotion_id INT, 
	@inicio DATETIME = NULL,
	@fim DATETIME = NULL,
	@descr VARCHAR(255) = NULL,
	@tempoExtra TIME = NULL
AS 
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN 
	BEGIN TRY
		EXEC ActualizarPromocao @promotion_id, @inicio, @fim, @descr
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW 50014, 'Transação interna interrompida', 1
	END CATCH
	IF(@tempoExtra IS NOT NULL)
	BEGIN
		UPDATE PromocaoTemporal 
			SET tempoExtra = @tempoExtra
			WHERE pId = @promotion_id
	END
	COMMIT

GO
CREATE PROCEDURE dbo.ActualizarPromocaoDesconto 
	@promotion_id INT, 
	@inicio DATETIME = NULL,
	@fim DATETIME = NULL,
	@descr VARCHAR(255) = NULL,
	@desconto FLOAT = NULL
AS 
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN 
	BEGIN TRY
		EXEC ActualizarPromocao @promotion_id, @inicio, @fim, @descr
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW 50013, 'Transação interna interrompida', 1
	END CATCH
	IF(@desconto IS NOT NULL)
		BEGIN
			UPDATE PromocaoDesconto 
				SET percentagemDesconto = @desconto
				WHERE pId = @promotion_id
		END
	COMMIT
GO
