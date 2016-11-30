USE AEnima
GO
IF OBJECT_ID('dbo.RemoverCliente') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverCliente

GO
CREATE PROC dbo.RemoverCliente @id INT
AS 
	IF(@id IS NULL) 
			THROW 50005, 'Id inv�lido', 1;
	IF(@id = 1) 
			THROW 50006, 'N�o se pode remover este Cliente', 1;
			-- XACT_ABORT should be on so no need to rollback here cause its autmaticly done
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRAN
		UPDATE dbo.Cliente
		SET valido = 0
		WHERE(@id = cId)

		DECLARE @now DATETIME = GETDATE()
		
		UPDATE dbo.Aluguer
		SET deleted = 1
		WHERE(@id = cliente AND @now > data_inicio)
	COMMIT 
GO