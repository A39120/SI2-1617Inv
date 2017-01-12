USE AEnima; 
--A tabela tem de estar vazia
INSERT INTO Tipo VALUES('Baldes', '')
INSERT INTO Empregado(nome) VALUES ('A')
exec InserirEquipamento 'Baldes', '' 
exec InserirPreco 'Baldes', 10, '01:00:00', '3000-10-10 10:00:00'
exec InserirPreco 'Baldes', 5, '00:45:00', '3000-10-10 10:00:00'
exec InserirPreco 'Baldes', 6, '01:45:00', '3000-10-10 10:00:00'
exec InserirPromocaoTemporal '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', '01:00:00'
exec InserirPromocaoDesconto '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', 0.5
exec InserirPromocaoDesconto '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', 0.5
exec InserirPromocaoTemporal '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', '01:00:00'
