-- TEST F: (j) Listar todos os equipamentos livres, para um determinado tempo e tipo;
INSERT INTO Empregado(nome) VALUES('Empregado') -- empregado com numero a 1
INSERT INTO Preco(tipo,	valor,	duracao , validade)  VALUES ('Tipo 1', 20, '01:30:00.0000000', '2019-12-27 13:00:00')
exec InserirAluguer 1, 1, 1, '2016-12-26 13:00:00', '01:30:00.0000000', 20

SELECT @rowcount = count(*) FROM EquipamentosLivres(GETDATE(), GETDATE(), 'Tipo 1')