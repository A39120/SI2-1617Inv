-- TEST C (ponto e): INSERT, REMOVE AND UPDATE PROMOÇÃO

USE AEnima
INSERT INTO Tipo VALUES('Generic','')
-- HAS HAPPENED
exec InserirPromocaoTemporal '2010-10-20 13:00:00', '2011-10-20 13:00:00', '1', 'Generic', '13:00:00' -- pId = 1
IF NOT EXISTS(SELECT * FROM PromocaoTemporal WHERE pId = 1)
	RAISERROR ('Test Error 1: PromocaoTemporal wasnt created.', 10,  1);
exec InserirPromocaoDesconto '2010-10-20 13:00:00', '2011-10-20 13:00:00', '1', 'Generic', 0.5		  -- pId = 2
IF NOT EXISTS(SELECT * FROM PromocaoDesconto WHERE pId = 2)
	RAISERROR ('Test Error 2: PromocaoDesconto wasnt created.', 10,  1);
-- HAPPENING
exec InserirPromocaoTemporal '2010-10-20 13:00:00', '2020-10-20 13:00:00', '1', 'Generic', '13:00:00' -- pId = 3
exec InserirPromocaoDesconto '2010-10-20 13:00:00', '2020-10-20 13:00:00', '1', 'Generic', 0.5		  -- pId = 4
-- HAS NOT HAPPEN 
exec InserirPromocaoTemporal '2020-10-20 13:00:00', '2030-10-20 13:00:00', '1', 'Generic', '13:00:00' -- pId = 5
exec InserirPromocaoDesconto '2020-10-20 13:00:00', '2030-10-20 13:00:00', '1', 'Generic', 0.5		  -- pId = 6

--TRYING TO INSERT WITH tempoExtra = NULL
BEGIN TRY
	exec InserirPromocaoTemporal '2010-10-20 13:00:00', '2011-10-20 13:00:00', '1', 'Generic', NULL	  -- pId = 7
	RAISERROR ('Test Error 3: Inserted with illegal parameters.', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 4: Test transaction still up after error.', 10,  1);
	IF EXISTS(SELECT * FROM PromocaoTemporal WHERE pId = 7)
		RAISERROR ('Test Error 5: PromocaoTemporal with pId 7 was created with errors.', 10,  1);
	IF EXISTS(SELECT * FROM Promocao WHERE pId = 7)
		RAISERROR ('Test Error 6: Promocao with pId 7 exists after trying to create a PromocaoTemporal', 10,  1);
END CATCH

--TRYING TO INSERT WITH DESCONTO = NULL
BEGIN TRY
	exec InserirPromocaoDesconto '2010-10-20 13:00:00', '2011-10-20 13:00:00', '1', 'Generic', NULL	  -- pId = 8
	RAISERROR ('Test Error 7: Inserted with illegal parameters.', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 8: Test transaction still up after error.', 10,  1);
	IF EXISTS(SELECT * FROM PromocaoTemporal WHERE pId = 8)
		RAISERROR ('Test Error 9: PromocaoTemporal with pId 7 was created with errors.', 10,  1);
	IF EXISTS(SELECT * FROM Promocao WHERE pId = 8)
		RAISERROR ('Test Error 10: Promocao with pId 7 exists after trying to create a PromocaoTemporal', 10,  1);
END CATCH

--TRYING TO INSERT WITH NON-EXISTING TIPO
BEGIN TRY
	exec InserirPromocaoDesconto '2010-10-20 13:00:00', '2011-10-20 13:00:00', '1', 'NonGeneric', 0.5	  -- pId = 9
	RAISERROR ('Test Error 11: Inserted with illegal parameters.', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 12: Test transaction still up after error.', 10,  1);
	IF EXISTS(SELECT * FROM PromocaoTemporal WHERE pId = 9)
		RAISERROR ('Test Error 13: PromocaoTemporal with pId 7 was created with errors.', 10,  1);
	IF EXISTS(SELECT * FROM Promocao WHERE pId = 9)
		RAISERROR ('Test Error 14: Promocao with pId 7 exists after trying to create a PromocaoTemporal', 10,  1);
END CATCH

--UPDATE DESCR ONLY
exec ActualizarPromocaoDesconto @promotion_id = 6, @descr = '6'
	IF NOT EXISTS(SELECT * FROM Promocao WHERE pId = 6 AND descr = '6')
		RAISERROR ('Test Error 14: Couldnt update Promotion 6', 10,  1);
--UPDATING UNEXISTING PROMOTION
BEGIN TRY
	exec ActualizarPromocaoDesconto @promotion_id = 10000, @descr = '10000'
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 16: Test transaction still up after error.', 10,  1);
	IF EXISTS(SELECT * FROM PromocaoDesconto WHERE pId = 10000)
		RAISERROR ('Test Error 17: PromocaoDesconto with pId 10000 exists.', 10,  1);
END CATCH
--TRYING TO UPDATE A PromocaoDesconto WITH PROC ActualizarPromocaoTemporal
BEGIN TRY
	exec ActualizarPromocaoDesconto @promotion_id=1, @descr = 'Updated this PromocaoTemporal with ActualizarPromocaoDesconto'
	RAISERROR ('Test WARNING 1: Updated something from type PromocaoTemporal, using the procedure ActualizarPromocaoDesconto, without specifying values that are specific to the type', 10,  1);
	exec ActualizarPromocaoTemporal @promotion_id=2, @descr = 'Updated this PromocaoDesconto with ActualizarPromocaoTemporal'
	RAISERROR ('Test WARNING 2: Updated something from type PromocaoDesconto, using the procedure ActualizarPromocaoTemporal, without specifying values that are specific to the type', 10,  1);
	exec ActualizarPromocaoDesconto @promotion_id=1, @desconto=0.5
	RAISERROR ('Test WARNING 3: Updated something from type PromocaoTemporal, using the procedure ActualizarPromocaoDesconto, specifying values that are specific to the type', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 19: Test transaction still up after error.', 10,  1);
	IF EXISTS(SELECT * FROM PromocaoDesconto WHERE pId = 1 AND percentagemDesconto = 0.5)
		RAISERROR ('Test Error 20: PromocaoDesconto with pId 1 exists.', 10,  1);
END CATCH


exec RemoverPromocaoTemporal 5
IF EXISTS(SELECT * FROM PromocaoTemporal WHERE pId = 5)
	RAISERROR ('Test Error 21: PromocaoDesconto with pId 5 still exists in PromocaoTemporal.', 10,  1);
IF EXISTS(SELECT * FROM Promocao WHERE pId = 5)
	RAISERROR ('Test Error 22: PromocaoDesconto with pId 5 still exists in Promocao.', 10,  1);
IF EXISTS(SELECT * FROM TipoPromocao WHERE pId = 5)
	RAISERROR ('Test Error 23: PromocaoDesconto with pId 5 still exists in TipoPromocao.', 10,  1);
exec RemoverPromocaoDesconto 6
IF EXISTS(SELECT * FROM PromocaoDesconto WHERE pId = 6)
	RAISERROR ('Test Error 24: PromocaoDesconto with pId 6 still exists.', 10,  1);
IF EXISTS(SELECT * FROM Promocao WHERE pId = 6)
	RAISERROR ('Test Error 25: PromocaoDesconto with pId 6 still exists in Promocao.', 10,  1);
IF EXISTS(SELECT * FROM TipoPromocao WHERE pId = 5)
	RAISERROR ('Test Error 26: PromocaoDesconto with pId 6 still exists in TipoPromocao.', 10,  1);
BEGIN TRY
	exec RemoverPromocaoDesconto 3
END TRY
BEGIN CATCH
	IF NOT EXISTS(SELECT * FROM PromocaoTemporal WHERE pId = 3)
		RAISERROR ('Test Error 24: PromocaoTemporal with pId 3 no longer exists.', 10,  1);
	IF NOT EXISTS(SELECT * FROM Promocao WHERE pId = 3)
		RAISERROR ('Test Error 25: PromocaoTemporal with pId 3 no longer exists in Promocao.', 10,  1);
	IF NOT EXISTS(SELECT * FROM TipoPromocao WHERE pId = 3)
		RAISERROR ('Test Error 26: PromocaoTemporal with pId 3 no longer exists in TipoPromocao.', 10,  1);
END CATCH