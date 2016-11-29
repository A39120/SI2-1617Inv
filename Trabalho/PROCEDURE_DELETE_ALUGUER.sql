USE AEnima;
IF OBJECT_ID('dbo.RemoverAluguer') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverAluguer

GO

CREATE PROCEDURE dbo.RemoverAluguer 
	@serial VARCHAR(31)
AS
	-- cannot actually remove a rental, so just mark it as deleted
	BEGIN TRAN
		UPDATE dbo.Aluguer
		SET deleted = 0
		WHERE(serial = @serial)

		DELETE FROM AluguerDataFim WHERE(serial_adf = @serial)
		DELETE FROM AluguerPrecoDuracao WHERE(serial_apd = @serial)
	COMMIT
GO