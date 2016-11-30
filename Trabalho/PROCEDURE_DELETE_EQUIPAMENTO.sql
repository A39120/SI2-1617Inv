USE AEnima 
IF OBJECT_ID('dbo.RemoverEquipamento') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverEquipamento

GO
CREATE PROCEDURE dbo.RemoverEquipamento @id INT
AS
	BEGIN TRAN
	DECLARE @now DATETIME = GETDATE()

	IF EXISTS(
		SELECT eqId
		FROM dbo.AluguerView
		INNER JOIN dbo.AluguerDataFim ON(serial = serial_adf)
		WHERE(eqId = @id AND data_fim > @now)
	) 
	BEGIN
		-- nao sei bem se isto e o mais correto a fazer, mas como nao sabia como proceder fiz isto
		DECLARE @msg VARCHAR(MAX) = CONCAT('O equipamento com eid=', @id, ' est� em uso'); 
		THROW 50129, @msg, 1 
	END

	DELETE FROM Equipamento WHERE eqId = @id

	COMMIT
GO