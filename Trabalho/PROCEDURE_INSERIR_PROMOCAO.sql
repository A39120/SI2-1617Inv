USE AEnima 
IF OBJECT_ID('dbo.InserirPromocao') IS NOT NULL 
	DROP PROCEDURE dbo.InserirPromocao
IF OBJECT_ID('dbo.InserirPromocaoTemporal') IS NOT NULL 
	DROP PROCEDURE dbo.InserirPromocaoTemporal
IF OBJECT_ID('dbo.InserirPromocaoDesconto') IS NOT NULL 
	DROP PROCEDURE dbo.InserirPromocaoDesconto

GO 
CREATE PROCEDURE dbo.InserirPromocao @inicio DATETIME, 
	@fim DATETIME,
	@descricao VARCHAR(255),
	@tipo VARCHAR(31),
	@id INT OUTPUT
AS 
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  
	BEGIN TRAN -- 2 escritas
	DECLARE @promTable TABLE (prom INT)
	INSERT INTO Promocao(inicio, fim, descr) 
		OUTPUT INSERTED.pId  INTO @promTable
		VALUES (@inicio, @fim, @descricao)
	SELECT @id = prom FROM @promTable 
	INSERT INTO TipoPromocao VALUES (@tipo, @id)
	COMMIT
GO
CREATE PROCEDURE dbo.InserirPromocaoTemporal 
	@inicio DATETIME, 
	@fim DATETIME,
	@descricao VARCHAR(255),
	@tipo VARCHAR(31),
	@tempoExtra TIME
AS
	BEGIN TRAN -- 2 escritas
	DECLARE @id INT
	EXEC InserirPromocao @inicio, @fim, @descricao, @tipo, @id output
	INSERT INTO PromocaoTemporal 
		VALUES (@id, @tempoExtra)
	COMMIT

GO
CREATE PROCEDURE dbo.InserirPromocaoDesconto @inicio DATETIME, 
	@fim DATETIME, 
	@descricao VARCHAR(255),
	@tipo VARCHAR(31),
	@desconto FLOAT
AS
	BEGIN TRAN -- 2 escritas
	DECLARE @id INT
	EXEC InserirPromocao @inicio, @fim, @descricao, @tipo, @id output
	INSERT INTO PromocaoDesconto
		VALUES (@id, @desconto)
	COMMIT

GO