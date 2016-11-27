USE AEnima

IF OBJECT_ID('AluguerView') IS NOT NULL
	DROP VIEW AluguerView


GO
CREATE VIEW AluguerView AS 
	SELECT * FROM Aluguer a 
	INNER JOIN AluguerPrecoDuracao apd ON (a.serial = apd.serial_apd) 
	INNER JOIN AluguerDataFim adf ON (apd.serial_apd = adf.serial_adf)