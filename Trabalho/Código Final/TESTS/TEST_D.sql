-- TEST D: 
-- (f) Inserir um aluguer com inserção de um cliente com dados completos;
-- (g) Inserir um aluguer usando um cliente existente;
-- (h) Remover um aluguer;					
USE AEnima
DECLARE @cliente INT 
exec InserirEquipamentoComTipo 'Tipo 1' --Equipamento eqId = 1
INSERT INTO Empregado(nome) VALUES('Empregado') -- Empregado eId = 1
exec InserirPreco 'Tipo 1', 1, '00:30:00', '2020-10-20 13:00:00'
exec InserirCliente 'Cliente Criado', 1, 'Test Street', @cliente output 
-- NORMAL INSERT WITHOUT ERRORS 

DECLARE @AluguerSerial1 VARCHAR(36), @novoCliente INT
exec InserirAluguerComNovoCliente 2, 'Novo Cliente', 'Test Street', 1, 1, '2010-10-21 13:00:00', '00:30:00', 1 
SELECT @novoCliente = c.cId FROM ClienteView c WHERE nome = 'Novo Cliente' AND nif = 2
IF (@novoCliente IS NULL)
	RAISERROR ('Test Error 1: Cliente was not created.', 10,  1);
SELECT @AluguerSerial1=serial FROM AluguerView WHERE cliente = @novoCliente
IF (@AluguerSerial1 IS NULL)
	RAISERROR ('Test Error 2: Aluguer was not created.', 10,  1);

DECLARE @AluguerSerial2 VARCHAR(36)
exec InserirAluguer 1, @cliente, 1, '2010-10-22 13:00:00', '00:30:00', 1
SELECT @AluguerSerial2=serial FROM AluguerView WHERE cliente = @novoCliente
IF (@AluguerSerial2 IS NULL)
	RAISERROR ('Test Error 3: Aluguer with existing client was not created.', 10,  1);

-- INSERT WITH NEW INVALID CLIENT 
BEGIN TRY
	exec InserirAluguerComNovoCliente 3, NULL, 'Test Street', 1, 1, '2010-10-23 13:00:00', '00:30:00', 1
	RAISERROR ('Test Error 4: Completed while forcing error on Cliente.', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 5: Test transaction still up after error.', 10,  1);
	DECLARE @AluguerSerial3 VARCHAR(36), @novoCliente2 INT
	SELECT @novoCliente2 = c.cId FROM ClienteView c WHERE nif = 3
	SELECT @AluguerSerial3=serial FROM AluguerView WHERE cliente = @novoCliente2
	IF (@AluguerSerial3 IS NOT NULL OR @novoCliente2 IS NOT NULL)
		RAISERROR ('Test Error 6: Aluguer/Cliente was created after error.', 10,  1);
END CATCH

-- InserirAluguerComNovoCliente WHILE FORCING ERROR ON Aluguer
BEGIN TRY
	exec InserirAluguerComNovoCliente 4, 'Novo Cliente 2', 'Test Street', 1, 1, NULL, '00:30:00', 1
	RAISERROR ('Test Error 7: Completed while forcing error on Aluguer.', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 8: Test transaction still up after error.', 10,  1);
	
	DECLARE @AluguerSerial4 VARCHAR(36), @novoCliente3 INT
	SELECT @novoCliente3 = c.cId FROM ClienteView c WHERE nif = 4
	SELECT @AluguerSerial4=serial FROM AluguerView WHERE cliente = @novoCliente3
	IF (@AluguerSerial4 IS NOT NULL OR @novoCliente3 IS NOT NULL)
		RAISERROR ('Test Error 9: Aluguer/Cliente was created after error.', 10,  1);
END CATCH

-- INSERT AN Aluguer THAT IS IN THE SAME TIME AS ANOTHER Aluguer
BEGIN TRY
	exec InserirAluguer 1, @cliente, 1, '2010-10-22 13:00:00', '00:30:00', 1
	RAISERROR ('Test Error 10: Inserted another Aluguer when it already has another Aluguer.', 10,  1);
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 11: Test transaction still up after error.', 10,  1);
	DECLARE @AluguerSerial5 VARCHAR(36), @novoCliente4 INT
	SELECT @novoCliente4 = c.cId FROM ClienteView c WHERE nif = 4
	SELECT @AluguerSerial5=serial FROM AluguerView WHERE cliente = @novoCliente4
	IF (@AluguerSerial5 IS NOT NULL OR @novoCliente4 IS NOT NULL)
		RAISERROR ('Test Error 12: Aluguer/Cliente was created after error.', 10,  1);
END CATCH

-- REMOVE ALUGUER TEST
exec RemoverAluguer @AluguerSerial2
IF EXISTS(SELECT * FROM AluguerView WHERE serial = @AluguerSerial2)
	RAISERROR ('Test Error 13: Aluguer was not removed.', 10,  1);

exec RemoverCliente @novoCliente
IF EXISTS(SELECT * FROM AluguerView WHERE serial = @AluguerSerial1)
	RAISERROR ('Test Error 14: Aluguer was not removed.', 10,  1);