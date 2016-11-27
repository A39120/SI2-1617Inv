--(f) Inserir um aluguer com inserção de um cliente com dados completos;
USE AEnima;
IF OBJECT_ID('dbo.InserirAluguerComNovoCliente') IS NOT NULL 
	DROP PROCEDURE dbo.InserirAluguerComNovoCliente

GO

CREATE PROCEDURE dbo.InserirAluguerComNovoCliente
	@empregado INT, 
	@cliente INT, 
	@eqId INT,
	@inicioAluguer DATETIME, 
	@duracao TIME,
	@preco FLOAT
	--@pid INT = NULL -- cliente escolhe de antemão qual a promoção que quer (de um catálogo prolly ?)
AS 
	IF NOT EXISTS(SELECT * FROM Cliente WHERE cId = @cliente)
		THROW 50020, 'O Cliente inserido não existe.', 1;
	--VERIFICAR SE EQUIPAMENTO EXISTE
	IF NOT EXISTS(SELECT * FROM Equipamento WHERE eqId = @eqId)
		THROW 50021, 'O Equipamento inserido não existe.', 1;
	--VERIFICAR SE EMPREGADO EXISTE
	IF NOT EXISTS(SELECT * FROM Empregado WHERE eId = @empregado)
		THROW 50022, 'O Empregado inserido não existe.', 1;
		
	--VERIFICAR SE PREÇO EXISTE
	DECLARE @precoValidade DATE
	SELECT validade = @precoValidade FROM Preco WHERE valor = @preco --Queria verificar se a validade era viavel
	
	DECLARE @discount INT -- [0.0 , 1.0]

	-- variável = coluna ? ou coluna = variável ? XD
	SELECT TOP 1 percentagemDesconto = @discount FROM Equipamento eq INNER JOIN Tipo t ON (eq.tipo = t.nome)
										INNER JOIN TipoPromocao tp ON (t.nome = tp.tipo)
										INNER JOIN PromocaoDesconto pd ON (tp.pId = pd.pId)

	DECLARE @moddedPrice FLOAT = @preco - (@preco * @discount)

	DECLARE @extraTime TIME
	SELECT TOP 1 tempoExtra = @extraTime FROM Equipamento eq INNER JOIN Tipo t ON (eq.tipo = t.nome)
										INNER JOIN TipoPromocao tp ON (t.nome = tp.tipo)
										INNER JOIN PromocaoTemporal pd ON (tp.pId = pd.pId)

	DECLARE @moddedTime TIME = @duracao + @extraTime
	-- Ok e se a promoção for de PromocaoTemporal?????
	-- Copy above and change var to moddedTime
	-- E se existirem duas promoções para o mesmo uma de desconto, outra temporal
	-- LET ME FINISH! Ou até existirem promoções que estão fora de validade

	--- I said copy above, vai haver código para preço e outro para tempo parecidos

	-- Mas tens duas promoções e so podes escolher uma certo?
	-- TOP 1, there done XD
	-- BULLSHIT THIS SO BULLSHIT,primeira a ser inserida é a que assumimos como válida para o momento.
	-- O cliente é que deve decidir a promoção que quer,
	-- é estúpido estar com duas promoções de desconto com valores diferentes ao mesmo tempo...
	-- o cliente vai sempre querer o mais barato...
	-- O cliente so pode decidir numa promoção certo, normalmente é sempre assim
	-- Ele tem a escolha: Tempo ou desconto. Qual delas?
	-- acho que as promos aqui não são assim, se houver as duas o cliente leva com as duas
	-- +tempo e -$$$

	
	INSERT INTO Aluguer(eqId, empregado, cliente, data_inicio)
		VALUES(@eqId, @empregado, @cliente, @inicioAluguer)
	
GO
--exec dbo.InserirCliente 'João Lopes', 250668122, 'Avn. Isel'
--exec dbo.InserirCliente NULL, 1, 'a