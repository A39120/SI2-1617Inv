-- TEST A: INSERT, REMOVE AND UPDATE CLIENTE

USE AEnima
-- SIMPLE TESTS, INSERT, UPDATE and DELETE
GO
DECLARE @id INT
DECLARE @aluguerId VARCHAR(36)
exec InserirCliente 'Michael Hunter', 999999999, 'Test avn.', @id output
IF NOT EXISTS(SELECT * FROM ClienteView WHERE cId = @id)
	RAISERROR ('Test Error 1: This client doesnt exist.', 10,  1);
exec ActualizarCliente @id, 'John', 999999999, 'Test avn.'
IF EXISTS(SELECT * FROM ClienteView WHERE nome = 'Michael Hunter')
	RAISERROR ('Test Error 2: This client didnt update.', 10,  1);
exec RemoverCliente @id
IF EXISTS(SELECT cId FROM ClienteView WHERE cId = @id)
	RAISERROR ('Test Error 3: This client still exists.', 10,  1);
-- SIMPLE TESTS, FORCE ERROR WITH VALUES AT NULL
BEGIN TRY
    exec InserirCliente 'Michael Hunter', 999999999, NULL, NULL;
END TRY
BEGIN CATCH
    IF(@@trancount > 0) 
		RAISERROR ('Test Error 4: Test transaction still up.', 10,  1);
	IF EXISTS(SELECT * FROM ClienteView WHERE nome = 'Michael Hunter')
		RAISERROR ('Test Error 5: Client was inserted with errors.', 10,  1);
END CATCH;


-- DELETE CLIENT THAT DID AN ALUGUER IN THE PAST
exec InserirCliente 'Michael Hunter', 999999999, 'Test avn.', @id output
exec InserirEquipamentoComTipo 'Gaivota' --Equipamento com id a 1
INSERT INTO Empregado(nome) VALUES('Empregado') -- empregado com numero a 1
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Gaivota', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, @id, 1, '2016-12-27 13:00:00', '01:30:00.0000000', 20
SELECT @aluguerId = serial FROM AluguerView WHERE cliente = @id
IF(@aluguerId = NULL OR @id = NULL AND @@TRANCOUNT > 0)
	RAISERROR ('Test Error 6: Failed to insert new Aluguer/Cliente.', 10,  1);

DECLARE @auxCliente INT, @auxAluguer VARCHAR(36)
exec RemoverCliente @id

SELECT @auxCliente=cId FROM ClienteView WHERE cId = @id
SELECT @auxAluguer=serial FROM AluguerView WHERE cliente = @id
IF(@auxCliente IS NOT NULL AND @auxAluguer IS NOT NULL AND @@TRANCOUNT > 0)
	RAISERROR ('Test Error 7: Aluguer/Cliente still exist', 10,  1);

--RESET THE TABLES