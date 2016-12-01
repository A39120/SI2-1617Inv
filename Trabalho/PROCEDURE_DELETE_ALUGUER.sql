USE AEnima;
IF OBJECT_ID('dbo.RemoverAluguer') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverAluguer

GO

CREATE PROCEDURE dbo.RemoverAluguer 
	@serial VARCHAR(36)
AS
	-- cannot actually remove a rental, so just mark it as deleted
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRAN
		UPDATE dbo.Aluguer
			SET deleted = 1
			WHERE(serial = @serial)

		DELETE FROM AluguerDataFim WHERE(serial_adf = @serial)
		DELETE FROM AluguerPrecoDuracao WHERE(serial_apd = @serial)
	COMMIT
GO

CREATE PROCEDURE dbo.RemoverAlugueresParaCliente 
	@cid INT
AS
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	BEGIN TRAN
		
		UPDATE dbo.Aluguer SET deleted = 1
		WHERE(cliente = @cid)

		DELETE FROM AluguerDataFim WHERE(serial_adf IN(
			SELECT serial 
			FROM dbo.Aluguer
			WHERE(cliente = @cid))
		)
		
		DELETE FROM AluguerPrecoDuracao WHERE(serial_apd IN(
			SELECT serial 
			FROM dbo.Aluguer
			WHERE(cliente = @cid))
		)

	COMMIT
GO