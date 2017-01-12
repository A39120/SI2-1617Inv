USE AEnima 
IF OBJECT_ID('dbo.RemoverEquipamento') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverEquipamento

GO
CREATE PROCEDURE dbo.RemoverEquipamento @id INT
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN
	DECLARE @now DATETIME = GETDATE()

	IF EXISTS(SELECT equipamento FROM dbo.AluguerView
				INNER JOIN dbo.AluguerDataFim ON(id = serial_adf)
				WHERE(equipamento = @id AND data_fim > @now)) 
	BEGIN
		ROLLBACK TRAN;
		DECLARE @msg VARCHAR(MAX) = CONCAT('O equipamento com eid=', @id, ' está em uso'); 
		THROW 50129, @msg, 1 
	END

	UPDATE Equipamento SET valid = 0 WHERE (eqId = @id)
	COMMIT
GO