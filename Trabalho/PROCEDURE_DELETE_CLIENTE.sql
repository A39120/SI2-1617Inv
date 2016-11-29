USE AEnima
GO
IF OBJECT_ID('dbo.RemoverCliente') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverCliente

GO
CREATE PROC dbo.RemoverCliente @id INT
AS 
	IF(@id IS NULL) 
		BEGIN
			ROLLBACK
			THROW 50005, 'Id inválido', 1;
		END
	ELSE IF(@id = 1) 
		BEGIN
			ROLLBACK
			THROW 50006, 'Não se pode remover este Cliente', 1;
		END
	ELSE DELETE FROM Cliente WHERE cId = @id
	--TODO: Apagar alugueres que ainda não aconteceram
GO
exec dbo.RemoverCliente NULL
exec dbo.RemoverCliente 2