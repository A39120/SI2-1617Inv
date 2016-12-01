-- TEST F: (j) Listar todos os equipamentos livres, para um determinado tempo e tipo;exec InserirEquipamentoComTipo 'Tipo 1'exec InserirEquipamentoComTipo 'Tipo 2'exec InserirEquipamento 'Tipo 1'exec InserirEquipamento 'Tipo 2'exec InserirEquipamento 'Tipo 1'exec InserirEquipamento 'Tipo 2'DECLARE @rowcount INT = 0SELECT @rowcount = count(*) FROM EquipamentosLivres(GETDATE(), GETDATE(), 'Tipo 1')IF(@rowcount != 3)	RAISERROR ('Test Error 1: Number of rows wrong.', 10,  1);SET @rowcount = 0
INSERT INTO Empregado(nome) VALUES('Empregado') -- empregado com numero a 1
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Tipo 1', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, 1, 1, '2016-12-26 13:00:00', '01:30:00.0000000', 20

SELECT @rowcount = count(*) FROM EquipamentosLivres(GETDATE(), GETDATE(), 'Tipo 1')IF(@rowcount != 3)	RAISERROR ('Test Error 2: Number of rows wrong: %d.', 10,  1, @rowcount);SET @rowcount = 0SELECT @rowcount = count(*) FROM EquipamentosLivres('2016-12-25 13:00:00', GETDATE(), 'Tipo 1')IF(@rowcount != 2)	RAISERROR ('Test Error 3: Number of rows wrong, expected 2: %d', 10,  1, @rowcount);SELECT * FROM EquipamentosLivres('2016-12-25 13:00:00', GETDATE(), 'Tipo 1')SELECT eq.* FROM Tipo t
		INNER JOIN EquipamentoDisponivelView eq ON(t.nome = eq.tipo)
		WHERE NOT EXISTS (
			SELECT * FROM Aluguer al 
				INNER JOIN AluguerPrecoDuracao apd ON (al.serial = apd.serial_apd)
				INNER JOIN AluguerDataFim adf ON (apd.serial_apd = adf.serial_adf)
				WHERE (al.data_inicio BETWEEN '2016-12-26 13:00:00' AND GETDATE()) OR (adf.data_fim BETWEEN '2016-12-26 13:00:00' AND GETDATE())
		) AND  eq.tipo = 'Tipo 1'
