USE AEnima;
IF OBJECT_ID('dbo.RemoverAluguer') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverAluguer

GO
--INSERE UM ALUGUER COM CLIENTE ESPECIFICADO
CREATE PROCEDURE dbo.RemoverAluguer 
	@serial VARCHAR(31)
AS
	--opção 1: Verificamos se pode ser removido com um Trigger instead of - 3 triggers para (Aluguer, AluguerPrecoDuracao e AluguerDataFim)
	--opção 2: usar um trigger after para eleminar AluguerPrecoDuracao e AluguerDataFim
	DELETE FROM AluguerDataFim WHERE serial_adf = @serial
	DELETE FROM AluguerPrecoDuracao WHERE serial_apd = @serial
	DELETE FROM Aluguer WHERE serial = @serial