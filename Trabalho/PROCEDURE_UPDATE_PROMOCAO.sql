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
	BEGIN TRAN -- 1 leitura e 1 escrita vs 3 escritas
	DECLARE @customInicio DATETIME, @customFim DATETIME, @customDesc VARCHAR(255)
	SELECT inicio = @customInicio, fim = @customFim, descr = @customDesc
		FROM Promocao
		WHERE pId = @promotion_id
	IF(@inicio IS NOT NULL)  SET @customInicio = @inicio
	IF(@fim IS NOT NULL)  SET @customFim = @fim
	IF(@descr IS NOT NULL) SET @customDesc = @descr
	UPDATE Promocao 
		SET inicio = @inicio,
			fim = @fim, 
			descr = @descr
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
	BEGIN TRAN 
	EXEC ActualizarPromocao @promotion_id, @inicio, @fim, @descr
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
	BEGIN TRAN 
	EXEC ActualizarPromocao @promotion_id, @inicio, @fim, @descr
	IF(@desconto IS NOT NULL)
	BEGIN
		UPDATE PromocaoDesconto 
			SET percentagemDesconto = @desconto
			WHERE pId = @promotion_id
	END
	COMMIT
GO
