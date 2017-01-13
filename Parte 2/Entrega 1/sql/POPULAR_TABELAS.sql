USE AEnima


DELETE dbo.AluguerDataFim
DELETE dbo.AluguerPrecoDuracao
DELETE dbo.Aluguer
DELETE dbo.TipoPromocao
DELETE FROM dbo.Cliente WHERE cId > 1
DELETE dbo.Empregado
DELETE dbo.PromocaoTemporal
DELETE dbo.PromocaoDesconto
DELETE dbo.Promocao
DELETE dbo.Preco
DELETE dbo.Equipamento
DELETE dbo.Tipo


--10 Tipos
INSERT INTO Tipo VALUES('Chapeu De Palha'		   , 'Relaxar')
INSERT INTO Tipo VALUES('Toldo' 				   , 'Relaxar')
INSERT INTO Tipo VALUES('Espreguiçadeira'		   , 'Relaxar')
INSERT INTO Tipo VALUES('Tenda'					   , 'Relaxar')
INSERT INTO Tipo VALUES('Volleyball'			   , 'Desporto')
INSERT INTO Tipo VALUES('Caiaque'				   , 'Desporto')
INSERT INTO Tipo VALUES('Mota de Agua'			   , 'Desporto Radical')
INSERT INTO Tipo VALUES('Raquetes(Ping Pong Praia)', 'Desporto')
INSERT INTO Tipo VALUES('Football'				   , 'Desporto')
INSERT INTO Tipo VALUES('Baldes'				   , 'Divertimento')
INSERT INTO Tipo VALUES('Pás'					   , 'Divertimento')
INSERT INTO Tipo VALUES('Equipamento Diving'	   , 'Lazer')

--
DECLARE @loopCount INT = 1
WHILE (@loopCount > 0)
BEGIN
exec InserirEquipamentoComTipo 'Chapeu De Palha'		  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Toldo'					  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Espreguiçadeira'		  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Tenda'					  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Volleyball'				  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Caiaque'				  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Mota de Agua'			  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Raquetes(Ping Pong Praia)', 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Football'				  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Baldes'					  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Pás'					  , 'Equipamento Simples', NULL, NULL
exec InserirEquipamentoComTipo 'Equipamento Diving'		  , 'Equipamento Simples', NULL, NULL
SET @loopCount = @loopCount - 1 						  
END


-- Inserir 15 Clientes diferentes

exec InserirCliente 'João Lopes', 250668122, 'ISEL', @loopCount
exec InserirCliente 'Antonio Domingues', 000000003, 'Setubal' , @loopCount
exec InserirCliente 'Pinto da Costa', 000000004, 'Porto', @loopCount
exec InserirCliente 'Paços Coelho', 000000005, 'Ericeira', @loopCount
exec InserirCliente 'Edmund Freud', 000000006, 'Hamburg', @loopCount
exec InserirCliente 'Muhammed', 000000007, 'Fez', @loopCount
exec InserirCliente 'Henrique Infantes', 000000008, 'Sintra', @loopCount
exec InserirCliente 'Manuel Herrara', 000000009, 'Bogota', @loopCount
exec InserirCliente 'Pablo Escobar', 000000010, 'Menelin', @loopCount
exec InserirCliente 'Fidel Castro', 000000011, 'Cuba', @loopCount
exec InserirCliente 'Pedro Anacoreta', 000000012, 'Lisboa', @loopCount
exec InserirCliente 'William Gibbs', 000000013, 'Liverpool', @loopCount
exec InserirCliente 'Dilma Rouseff', 000000014, 'Rio de Janeiro', @loopCount
exec InserirCliente 'Xu', 000000015, 'Osaka', @loopCount

INSERT INTO Empregado VALUES ('João Lopes')
INSERT INTO Empregado VALUES ('Tiago Santos')
INSERT INTO Empregado VALUES ('João Correia')

SET @loopCount = 5
DECLARE @preco FLOAT = 5.0, @duracao TIME = '00:30:00'
--1 preço fora de validade para cada equipamento
INSERT INTO Preco VALUES('Chapeu De Palha', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Toldo', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Espreguiçadeira', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Tenda', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Volleyball', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Caiaque', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Mota de Agua', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Raquetes(Ping Pong Praia)', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Football', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Baldes', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Pás', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Equipamento Diving', @preco, @duracao, '1990-12-31 23:59:59')
--25 Preços dentro de validade para cada equipamento
WHILE (@loopCount > 0)
BEGIN 
	SET @preco = @preco * 2
	SET @duracao = DATEADD(MINUTE, 30, @duracao)
	INSERT INTO Preco VALUES('Chapeu De Palha', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Toldo', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Espreguiçadeira', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Tenda', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Volleyball', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Caiaque', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Mota de Agua', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Raquetes(Ping Pong Praia)', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Football', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Baldes', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Pás', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Equipamento Diving', @preco, @duracao, '2017-12-31 23:59:59')
	SET @loopCount = @loopCount - 1 			
END

DECLARE @aux INT = 0
--3 Promoções Temporais para 3 tipos
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de desconto','Chapeu De Palha', 0.1
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de desconto','Toldo', 0.2
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de desconto','Espreguiçadeira', 0.3
--3 Promoções Desconto para 3 tipos
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de Tempo','Tenda', '00:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de Tempo','Volleyball'	,'01:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de Tempo','Caiaque', '01:00:00'
-- 3 tipos com 2 promoções
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de desconto','Baldes', 0.1
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de desconto','Pás', 0.2
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de desconto','Equipamento Diving', 0.3
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de tempo','Baldes', '00:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de tempo','Pás','01:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promoção de tempo','Equipamento Diving', '01:00:00'

-- Inserir aluguer sem promoção, com preço e duração existentes, no cliente final, que já aconteceu
exec InserirAluguer @empregado = 1, @eqId = 1, @inicioAluguer = '2014-12-12 13:00:00', @duracao = '01:00:00', @preco = 10, @novoID = NULL
-- Inserir aluguer sem promoção, com preço e duração existentes, no cliente existente, que já aconteceu, na semana passada
exec InserirAluguer 1, 3, 2, '2016-12-27 13:00:00', '01:30:00.0000000', 20, NULL, NULL
-- Inserir aluguer sem promoção, com preço e duração existentes, no cliente existente, que está a acontecer
DECLARE @currentDate DATETIME = GETDATE()
exec InserirAluguer 1, 3, 3, @currentDate, '01:00:00', 10, 3, NULL
-- Inserir aluguer que ainda não aconteceu, com uma promoção temporal, com um novo cliente
exec InserirAluguerComNovoCliente 333322343,'New Client', 'SAvn.', 1, 4, '2017-05-31 23:59:59', '01:30:00', 20, 4, NULL