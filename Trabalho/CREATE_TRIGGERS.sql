USE AEnima;
GO
-- delete part
IF OBJECT_ID('dbo.TRG_DELETE_ALUGUER') IS NOT NULL
	DROP TRIGGER dbo.TRG_DELETE_ALUGUER

GO

CREATE TRIGGER dbo.TRG_DELETE_ALUGUER ON Aluguer 
AFTER DELETE
AS
	BEGIN TRAN
		DECLARE @serial VARCHAR(36) = (SELECT deleted.serial FROM deleted);
		DELETE FROM AluguerDataFim WHERE serial_adf = @serial
		DELETE FROM AluguerPrecoDuracao WHERE serial_apd = @serial
	COMMIT
GO