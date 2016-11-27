USE AEnima
GO
IF OBJECT_ID('dbo.RemoverCliente') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverCliente

GO
CREATE PROC dbo.RemoverCliente @id INT
AS 
	IF(@id IS NULL) THROW 50005, 'Id inv�lido', 1;
	ELSE IF(@id = 1) THROW 50006, 'N�o se pode remover este Cliente', 1;
	ELSE DELETE FROM Cliente WHERE cId = @id
	--TODO: Apagar alugueres que ainda n�o aconteceram
GO
exec dbo.RemoverCliente NULL
exec dbo.RemoverCliente 2