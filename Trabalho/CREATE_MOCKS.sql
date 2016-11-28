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
INSERT INTO Tipo VALUES('Espregui�adeira'		   , 'Relaxar')
INSERT INTO Tipo VALUES('Tenda'					   , 'Relaxar')
INSERT INTO Tipo VALUES('Volleyball'			   , 'Desporto')
INSERT INTO Tipo VALUES('Caiaque'				   , 'Desporto')
INSERT INTO Tipo VALUES('Mota de Agua'			   , 'Desporto Radical')
INSERT INTO Tipo VALUES('Raquetes(Ping Pong Praia)', 'Desporto')
INSERT INTO Tipo VALUES('Football'				   , 'Desporto')
INSERT INTO Tipo VALUES('Baldes'				   , 'Divertimento')
INSERT INTO Tipo VALUES('P�s'					   , 'Divertimento')
INSERT INTO Tipo VALUES('Equipamento Diving'	   , 'Lazer')

--
DECLARE @loopCount INT = 1
WHILE (@loopCount > 0)
BEGIN
exec InserirEquipamentoComTipo 'Chapeu De Palha'		  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Toldo'					  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Espregui�adeira'		  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Tenda'					  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Volleyball'				  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Caiaque'				  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Mota de Agua'			  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Raquetes(Ping Pong Praia)', 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Football'				  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Baldes'					  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'P�s'					  , 'Equipamento Simples'
exec InserirEquipamentoComTipo 'Equipamento Diving'		  , 'Equipamento Simples'
SET @loopCount = @loopCount - 1 						  
END


-- Inserir 15 Clientes diferentes

exec InserirCliente 'Jo�o Lopes', 250668122, 'ISEL', @loopCount
exec InserirCliente 'Antonio Domingues', 000000003, 'Setubal' , @loopCount
exec InserirCliente 'Pinto da Costa', 000000004, 'Porto', @loopCount
exec InserirCliente 'Pa�os Coelho', 000000005, 'Ericeira', @loopCount
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

INSERT INTO Empregado VALUES ('Jo�o Lopes')
INSERT INTO Empregado VALUES ('Tiago Santos')
INSERT INTO Empregado VALUES ('Jo�o Correia')

SET @loopCount = 5
DECLARE @preco FLOAT = 5.0, @duracao TIME = '00:30:00'
--1 pre�o fora de validade para cada equipamento
INSERT INTO Preco VALUES('Chapeu De Palha', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Toldo', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Espregui�adeira', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Tenda', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Volleyball', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Caiaque', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Mota de Agua', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Raquetes(Ping Pong Praia)', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Football', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Baldes', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('P�s', @preco, @duracao, '1990-12-31 23:59:59')
INSERT INTO Preco VALUES('Equipamento Diving', @preco, @duracao, '1990-12-31 23:59:59')
--25 Pre�os dentro de validade para cada equipamento
WHILE (@loopCount > 0)
BEGIN 
	SET @preco = @preco * 2
	SET @duracao = DATEADD(MINUTE, 30, @duracao)
	INSERT INTO Preco VALUES('Chapeu De Palha', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Toldo', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Espregui�adeira', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Tenda', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Volleyball', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Caiaque', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Mota de Agua', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Raquetes(Ping Pong Praia)', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Football', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Baldes', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('P�s', @preco, @duracao, '2017-12-31 23:59:59')
	INSERT INTO Preco VALUES('Equipamento Diving', @preco, @duracao, '2017-12-31 23:59:59')
	SET @loopCount = @loopCount - 1 			
END

DECLARE @aux INT = 0
--3 Promo��es Temporais para 3 tipos
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de desconto','Chapeu De Palha', 0.1
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de desconto','Toldo', 0.2
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de desconto','Espregui�adeira', 0.3
--3 Promo��es Desconto para 3 tipos
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de Tempo','Tenda', '00:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de Tempo','Volleyball'	,'01:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de Tempo','Caiaque', '01:00:00'
-- 3 tipos com 2 promo��es
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de desconto','Baldes', 0.1
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de desconto','P�s', 0.2
exec dbo.InserirPromocaoDesconto '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de desconto','Equipamento Diving', 0.3
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de tempo','Baldes', '00:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de tempo','P�s','01:30:00'
exec dbo.InserirPromocaoTemporal '2014-12-31 23:59:59', '2017-12-31 23:59:59','Promo��o de tempo','Equipamento Diving', '01:00:00'

-- Inserir aluguer sem promo��o, com pre�o e dura��o existentes, no cliente final, que j� aconteceu
exec InserirAluguer @empregado = 1, @eqId = 1, @inicioAluguer = '2014-12-12 13:00:00', @duracao = '01:00:00', @preco = 10
-- Inserir aluguer sem promo��o, com pre�o e dura��o existentes, no cliente existente, que j� aconteceu, na semana passada
exec InserirAluguer 1, 3, 2, '2016-12-27 13:00:00', '01:30:00.0000000', 20
-- Inserir aluguer sem promo��o, com pre�o e dura��o existentes, no cliente existente, que est� a acontecer
DECLARE @currentDate DATETIME = GETDATE()
exec InserirAluguer 1, 3, 3, @currentDate, '01:00:00', 10, 3
exec InserirAluguer 1, 3, 3, @currentDate, '01:00:00', 10, 3