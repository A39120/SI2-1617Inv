--(f) Inserir um aluguer com inser��o de um cliente com dados completos;
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
	--@pid INT = NULL -- cliente escolhe de antem�o qual a promo��o que quer (de um cat�logo prolly ?)
AS 
	IF NOT EXISTS(SELECT * FROM Cliente WHERE cId = @cliente)
		THROW 50020, 'O Cliente inserido n�o existe.', 1;
	--VERIFICAR SE EQUIPAMENTO EXISTE
	IF NOT EXISTS(SELECT * FROM Equipamento WHERE eqId = @eqId)
		THROW 50021, 'O Equipamento inserido n�o existe.', 1;
	--VERIFICAR SE EMPREGADO EXISTE
	IF NOT EXISTS(SELECT * FROM Empregado WHERE eId = @empregado)
		THROW 50022, 'O Empregado inserido n�o existe.', 1;
		
	--VERIFICAR SE PRE�O EXISTE
	DECLARE @precoValidade DATE
	SELECT validade = @precoValidade FROM Preco WHERE valor = @preco --Queria verificar se a validade era viavel
	
	DECLARE @discount INT -- [0.0 , 1.0]

	-- vari�vel = coluna ? ou coluna = vari�vel ? XD
	SELECT TOP 1 percentagemDesconto = @discount FROM Equipamento eq INNER JOIN Tipo t ON (eq.tipo = t.nome)
										INNER JOIN TipoPromocao tp ON (t.nome = tp.tipo)
										INNER JOIN PromocaoDesconto pd ON (tp.pId = pd.pId)

	DECLARE @moddedPrice FLOAT = @preco - (@preco * @discount)

	DECLARE @extraTime TIME
	SELECT TOP 1 tempoExtra = @extraTime FROM Equipamento eq INNER JOIN Tipo t ON (eq.tipo = t.nome)
										INNER JOIN TipoPromocao tp ON (t.nome = tp.tipo)
										INNER JOIN PromocaoTemporal pd ON (tp.pId = pd.pId)

	DECLARE @moddedTime TIME = @duracao + @extraTime
	-- Ok e se a promo��o for de PromocaoTemporal?????
	-- Copy above and change var to moddedTime
	-- E se existirem duas promo��es para o mesmo uma de desconto, outra temporal
	-- LET ME FINISH! Ou at� existirem promo��es que est�o fora de validade

	--- I said copy above, vai haver c�digo para pre�o e outro para tempo parecidos

	-- Mas tens duas promo��es e so podes escolher uma certo?
	-- TOP 1, there done XD
	-- BULLSHIT THIS SO BULLSHIT,primeira a ser inserida � a que assumimos como v�lida para o momento.
	-- O cliente � que deve decidir a promo��o que quer,
	-- � est�pido estar com duas promo��es de desconto com valores diferentes ao mesmo tempo...
	-- o cliente vai sempre querer o mais barato...
	-- O cliente so pode decidir numa promo��o certo, normalmente � sempre assim
	-- Ele tem a escolha: Tempo ou desconto. Qual delas?
	-- acho que as promos aqui n�o s�o assim, se houver as duas o cliente leva com as duas
	-- +tempo e -$$$

	
	INSERT INTO Aluguer(eqId, empregado, cliente, data_inicio)
		VALUES(@eqId, @empregado, @cliente, @inicioAluguer)
	
GO
--exec dbo.InserirCliente 'Jo�o Lopes', 250668122, 'Avn. Isel'
--exec dbo.InserirCliente NULL, 1, 'a