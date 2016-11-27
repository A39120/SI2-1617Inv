USE AEnima
IF OBJECT_ID('dbo.CalcularDuracaoPreco') IS NOT NULL 
	DROP FUNCTION  dbo.InserirAluguerComNovoCliente

GO
CREATE FUNCTION dbo.CalcularDuracaoPreco(@pid INT, @eqId INT, @preco FLOAT, @duracao TIME) 
RETURNS @moddedValues TABLE (preco FLOAT, duracao TIME)
AS BEGIN 
	--TODO: SET TRANSACTION LEVEL
	BEGIN TRAN
	DECLARE @precoComDesconto FLOAT, @desconto FLOAT, @tempoFinal TIME, @tempoExtra TIME
	SELECT @desconto = IsNull(percentagemDesconto, 0) FROM Equipamento eq 
			INNER JOIN Tipo t ON (t.nome = eq.tipo)
			INNER JOIN TipoPromocao tp ON (tp.tipo = t.nome)
			INNER JOIN Promocao p ON(p.pId = tp.pId)
			INNER JOIN PromocaoDesconto pd ON(pd.pId = p.pId)
		WHERE @pid = p.pId AND @eqId = eq.eqId;
	
	SELECT @tempoExtra = IsNull(tempoExtra, '00:00:00') FROM Equipamento eq 
			INNER JOIN Tipo t ON (t.nome = eq.tipo)
			INNER JOIN TipoPromocao tp ON (tp.tipo = t.nome)
			INNER JOIN Promocao p ON(p.pId = tp.pId)
			INNER JOIN PromocaoTemporal pd ON(pd.pId = p.pId)
		WHERE @pid = p.pId AND @eqId = eq.eqId 

	SET @precoComDesconto = @preco - (@preco * @desconto)
	SET @tempoFinal = @duracao + @tempoExtra

	INSERT INTO @moddedValues VALUES (@precoComDesconto, @tempoFinal)
	COMMIT
	RETURN
END

GO
CREATE FUNCTION dbo.CalcularSemanaPassada(@currentDate DATETIME) 
RETURNS @lastWeek TABLE (firstDay DATETIME, lastDay DATETIME)
AS 
BEGIN 
	RETURN;
END

GO
-- Listar todos os equipamentos livres, para um determinado tempo e tipo;
CREATE FUNCTION dbo.EquipamentosLivres(@inicio DATETIME, @fim DATETIME, @tipo VARCHAR(31))
RETURNS @livres TABLE(eqId INT, descr VARCHAR(255), tipo VARCHAR(31))
AS 
BEGIN 

	INSERT INTO  @livres SELECT eq.eqId, eq.descr, eq.tipo FROM Tipo t
		INNER JOIN Equipamento eq ON(t.nome = eq.tipo)
		INNER JOIN Aluguer al ON(al.eqId = eq.eqId)
		INNER JOIN AluguerPrecoDuracao apd ON (al.serial = apd.serial_apd)
		INNER JOIN AluguerDataFim adf ON(al.serial = adf.serial_adf)
		WHERE (@inicio > adf.data_fim) OR (al.data_inicio > @fim)
	RETURN;
END