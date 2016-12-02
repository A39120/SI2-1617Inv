-- TEST B (ponto d): INSERT, REMOVE AND UPDATE EQUIPAMENTO

USE AEnima
-- SIMPLE TESTS, INSERT, UPDATE and DELETE
GO
DECLARE @id INT = 1
-- INSERIR EQUIPAMENTO SEM TIPO DEFINIDO
BEGIN TRY 
	exec InserirEquipamento 'Gaivota', 'One Description'
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 1: Test transaction still up after error.', 10,  1);
	IF EXISTS(SELECT * FROM Equipamento WHERE tipo = 'Gaivota')
		RAISERROR ('Test Error 2: Equipamento was inserted without tipo.', 10,  1);
END CATCH

-- INSERIR EQUIPAMENTO COM TIPO DEFENIDO 
INSERT INTO Tipo VALUES ('Gaivota', 'Gaivota Description')
exec InserirEquipamento 'Gaivota', '1' -- id = 2
IF NOT EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE  descr = '1')
	RAISERROR ('Test Error 3: This Equipamento doesnt exist.', 10,  1);

-- INSERIR EQUIPAMENTO E UM NOVO TIPO
exec InserirEquipamentoComTipo 'Bola', 'Ball', 'Ball' -- id = 3
IF NOT EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE tipo = 'Bola' AND eqId = 3)
	RAISERROR ('Test Error 4: This Equipamento/Tipo doesnt exist.', 10,  1);
IF NOT EXISTS(SELECT * FROM TipoView WHERE nome = 'Bola')
	RAISERROR ('Test Error 5: New Tipo doesnt contain any Equipamento', 10,  1);

-- ACTUALIZAR UM EQUIPAMENTO COM TIPO INEXISTENTE
BEGIN TRY 
exec ActualizarEquipamento 2, 'Nonexistent'
RAISERROR ('Test Error 6: ActualizarEquipamento ran with a non-existing type.', 10,  1);
END TRY
BEGIN CATCH
IF(@@trancount > 0) 
	RAISERROR ('Test Error 7: Test transaction still up after error.', 10,  1);
IF NOT EXISTS(SELECT * FROM TipoView WHERE nome = 'Gaivota')
	RAISERROR ('Test Error 8: Gaivota doesnt have Equipamento 1', 10,  1);
END CATCH

-- ACTUALIZAR EQUIPAMENTO COM TIPO EXISTENTE
exec ActualizarEquipamento 2, 'Bola'
IF NOT EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE  eqId = 2 AND tipo = 'Bola')
	RAISERROR ('Test Error 9: This Equipamento still has the same type.', 10,  1);
IF EXISTS(SELECT * FROM TipoView WHERE nome = 'Gaivota')
	RAISERROR ('Test Error 10: Gaivota still has at least one Equipamento', 10,  1);

-- ACTUALIZAR EQUIPAMENTO COM NOVO TIPO
exec ActualizarEquipamentoComNovoTipo 2, 'NewType'
IF NOT EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE  eqId = 2 AND tipo = 'NewType')
	RAISERROR ('Test Error 11: This Equipamento still has the same type.', 10,  1);
IF NOT EXISTS(SELECT * FROM TipoView WHERE nome = 'NewType')
	RAISERROR ('Test Error 12: NewType doesnt have one Equipamento after created', 10,  1);

-- REMOVER EQUIPAMENTO EXISTENTE
exec RemoverEquipamento 3
IF EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE eqId = 3)
	RAISERROR ('Test Error 13: The Equipamento with id 2 is still in db after execution of procedure RemoverEquipamento ', 10,  1);
IF EXISTS(SELECT * FROM TipoView WHERE nome = 'Bola')
	RAISERROR ('Test Error 14: Bola still has one Equipamento', 10,  1);

-- REMOVER EQUIPAMENTO QUE ESTA NUM ALUGUER, EQUIPAMENTO id = 1
DECLARE @idCliente INT, @aluguerId VARCHAR(36)
exec InserirCliente 'Michael Hunter', 999999999, 'Test avn.', @idCliente output
INSERT INTO Empregado(nome) VALUES('Empregado') -- empregado com numero a 1
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('NewType', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, @idCliente, 2, '2016-12-27 13:00:00', '01:30:00.0000000', 20
SELECT @aluguerId = serial FROM AluguerView WHERE cliente = @idCliente AND eqId = 2
IF(@aluguerId = NULL AND @@TRANCOUNT > 0)
	RAISERROR ('Test Error 15: Failed to insert new Aluguer.', 10,  1);

BEGIN TRY
exec RemoverEquipamento 2
END TRY
BEGIN CATCH
	IF(@@trancount > 0) 
		RAISERROR ('Test Error 16: Test transaction still up after error.', 10,  1);
	IF NOT EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE eqId = 2)
		RAISERROR ('Test Error 17: The Equipamento with id 2 is no longer in db error', 10,  1);
	IF NOT EXISTS(SELECT * FROM AluguerView WHERE serial = @aluguerId AND eqId = 2)
		RAISERROR ('Test Error 18: Aluguer is no longer in view after deleting Equipamento ', 10,  1);
END CATCH

exec InserirEquipamento 'Bola' -- id = 4
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Bola', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, @idCliente, 4, '2015-12-27 13:00:00', '01:30:00.0000000', 20
SELECT @aluguerId = serial FROM AluguerView WHERE cliente = @idCliente AND eqId = 4

exec RemoverEquipamento 4
IF EXISTS(SELECT * FROM EquipamentoDisponivelView WHERE eqId = 4)
	RAISERROR ('Test Error 17: The Equipamento with id 4 is still in the database', 10,  1);
IF NOT EXISTS(SELECT * FROM AluguerView WHERE serial = @aluguerId AND eqId = 4)
	RAISERROR ('Test Error 18: Aluguer is no longer in view after deleting Equipamento ', 10,  1);

--RESET THE TABLES--