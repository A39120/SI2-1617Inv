-- TEST F: (j) Listar todos os equipamentos livres, para um determinado tempo e tipo;
USE AEnima
exec InserirEquipamentoComTipo 'Tipo 1'
exec InserirEquipamentoComTipo 'Tipo 2'
exec InserirEquipamento 'Tipo 1'
exec InserirEquipamento 'Tipo 2'
exec InserirEquipamento 'Tipo 1'
exec InserirEquipamento 'Tipo 2'

DECLARE @rowcount INT = 0
SELECT @rowcount = count(*) FROM EquipamentosLivres(GETDATE(), GETDATE(), 'Tipo 1')
IF(@rowcount != 3)
	RAISERROR ('Test Error 1: Number of rows wrong.', 10,  1);

SET @rowcount = 0
INSERT INTO Empregado(nome) VALUES('Empregado') -- empregado com numero a 1
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Tipo 1', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, 1, 1, '2016-12-26 13:00:00', '01:30:00.0000000', 20

SELECT @rowcount = count(*) FROM EquipamentosLivres(GETDATE(), GETDATE(), 'Tipo 1')
IF(@rowcount != 3)
	RAISERROR ('Test Error 2: Number of rows wrong: %d.', 10,  1, @rowcount);

SET @rowcount = 0
SELECT @rowcount = count(*) FROM EquipamentosLivres('2016-12-25 13:00:00', '2016-12-27 13:00:00', 'Tipo 1')
IF(@rowcount != 2)
	RAISERROR ('Test Error 3: Number of rows wrong, expected 2: %d', 10,  1, @rowcount);