USE AEnima 
IF OBJECT_ID('dbo.RemoverPromocaoTemporal') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverPromocaoTemporal
IF OBJECT_ID('dbo.RemoverPromocaoDesconto') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverPromocaoDesconto
IF OBJECT_ID('dbo.RemoverPromocao') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverPromocao

GO
	
CREATE PROCEDURE dbo.RemoverPromocao
	@pid INT
AS 
	BEGIN TRAN 
	DELETE FROM TipoPromocao WHERE pId = @pid
	DELETE FROM Promocao WHERE pId = @pid
	COMMIT 

GO

CREATE PROCEDURE dbo.RemoverPromocaoDesconto 
	@pid INT
AS 
	BEGIN TRAN 
	DELETE FROM PromocaoDesconto WHERE pId = @pid 
	EXEC RemoverPromocao @pid
	COMMIT 

GO 

CREATE PROCEDURE dbo.RemoverPromocaoTemporal 
	@pid INT
AS 
	BEGIN TRAN 
	DELETE FROM PromocaoTemporal WHERE pId = @pid 
	EXEC RemoverPromocao @pid
	COMMIT 
GO