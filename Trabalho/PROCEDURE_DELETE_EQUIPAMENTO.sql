USE AEnima 
IF OBJECT_ID('dbo.RemoverEquipamento') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverEquipamento

GO
CREATE PROCEDURE dbo.RemoverEquipamento @id INT
AS
	DELETE FROM Equipamento WHERE eqId = @id