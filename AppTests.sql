USE AEnima; 
--A tabela tem de estar vazia
INSERT INTO Tipo VALUES('Baldes', '')
INSERT INTO Empregado VALUES ('A')
declare @var int = 0;
exec InserirEquipamento 'Baldes', '', @var output
exec InserirPreco 'Baldes', 10, '01:00:00', '3000-10-10 10:00:00'
exec InserirPreco 'Baldes', 5, '00:45:00', '3000-10-10 10:00:00'
exec InserirPreco 'Baldes', 6, '01:45:00', '3000-10-10 10:00:00'
exec InserirPreco 'Baldes', 7, '00:50:00', '3000-10-10 10:00:00'
exec InserirPromocaoTemporal '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', '01:00:00'
exec InserirPromocaoDesconto '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', 0.5 
exec InserirPromocaoTemporal '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', '01:00:00'
exec InserirPromocaoDesconto '2000-10-10 10:00:00', '3000-10-10 10:00:00', '', 'Baldes', 0.5
exec InserirAluguer 1, 1, 1, '2000-10-11 10:00:00', '1:00:00', 10, 1, NULL

SELECT * FROM AluguerView
SELECT * FROM Preco
SELECT * FROM Promocao
SELECT * FROM PromocaoTemporal
SELECT * FROM PromocaoDesconto