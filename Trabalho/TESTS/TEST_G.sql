-- TEST G: (k) Listar os equipamentos sem alugueres na última semana
USE AEnima

exec InserirEquipamentoComTipo 'Tipo 1'
exec InserirEquipamentoComTipo 'Tipo 2'
exec InserirEquipamento 'Tipo 1'
exec InserirEquipamento 'Tipo 2'
exec InserirEquipamento 'Tipo 1'
exec InserirEquipamento 'Tipo 2'

DECLARE @rowcount INT = 0
SELECT @rowcount = count(*) FROM EquipamentosSemAlugueresNaUltimaSemana()
IF(@rowcount != 6)
	RAISERROR ('Test Error 1: Not all of the new Equipamentos are available.', 10,  1);

DECLARE @day7 DATETIME = DATEADD(DAY, -7, GETDATE()), 
		@day4 DATETIME = DATEADD(DAY, -4, GETDATE()), 
		@day3 DATETIME = DATEADD(DAY, -3, GETDATE()), 
		@day0 DATETIME = GETDATE()
 
SET @rowcount = 0
INSERT INTO Empregado(nome) VALUES('Empregado') -- empregado com numero a 1
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Tipo 1', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Tipo 2', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, 1, 1, @day7, '01:30:00.0000000', 20
exec InserirAluguer 1, 1, 2, @day4, '01:30:00.0000000', 20
exec InserirAluguer 1, 1, 3, @day3, '01:30:00.0000000', 20
exec InserirAluguer 1, 1, 4, @day0, '01:30:00.0000000', 20

SELECT @rowcount = count(*) FROM EquipamentosSemAlugueresNaUltimaSemana()
IF(@rowcount != 2)
	RAISERROR ('Test Error 2: Not all of the new Equipamentos are available. Available = %d', 10,  1, @rowcount);