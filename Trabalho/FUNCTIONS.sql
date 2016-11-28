USE AEnima
IF OBJECT_ID('dbo.CalcularDuracaoPreco') IS NOT NULL 
	DROP FUNCTION  dbo.CalcularDuracaoPreco
IF OBJECT_ID('dbo.EquipamentosLivres') IS NOT NULL 
	DROP FUNCTION  dbo.EquipamentosLivres
IF OBJECT_ID('dbo.EquipamentosSemAlugueresNaUltimaSemana') IS NOT NULL 
	DROP FUNCTION  dbo.EquipamentosSemAlugueresNaUltimaSemana


GO
CREATE FUNCTION dbo.CalcularDuracaoPreco(@pid INT, @eqId INT, @preco FLOAT, @duracao TIME) 
RETURNS @moddedValues TABLE (preco FLOAT, duracao TIME)
AS BEGIN 
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
	SET @tempoFinal = dateadd(ss, ((DATEPART(HOUR,@tempoExtra) * 60) + DATEPART(MINUTE,@tempoExtra) * 60) + DATEPART(SECOND,@tempoExtra), @duracao)
	INSERT INTO @moddedValues VALUES (@precoComDesconto, @tempoFinal)
	RETURN
END


GO
-- Listar todos os equipamentos livres, para um determinado tempo e tipo;
CREATE FUNCTION dbo.EquipamentosLivres(@inicio DATETIME, @fim DATETIME, @tipo VARCHAR(31) = NULL)
RETURNS @livres TABLE(eqId INT, descr VARCHAR(255), tipo VARCHAR(31))
AS 
BEGIN 
	INSERT INTO  @livres SELECT eq.* FROM Tipo t
		INNER JOIN Equipamento eq ON(t.nome = eq.tipo)
		WHERE NOT EXISTS (
			SELECT * FROM Aluguer al 
				INNER JOIN AluguerPrecoDuracao apd ON (al.serial = apd.serial_apd)
				INNER JOIN AluguerDataFim adf ON (al.serial = adf.serial_adf)
				WHERE al.data_inicio >= @inicio AND adf.data_fim >= @fim 
		) AND  eq.tipo = IsNull(@tipo, eq.tipo)
	RETURN;
END

GO
CREATE FUNCTION dbo.EquipamentosSemAlugueresNaUltimaSemana()
RETURNS @livres TABLE(eqId INT, descr VARCHAR(255), tipo VARCHAR(31))
AS 
BEGIN 
	DECLARE @fim DATETIME = GETDATE(), @inicio DATETIME = DATEADD(DAY, -7, GETDATE())
	INSERT INTO @livres 
		SELECT * FROM EquipamentosLivres(@inicio, @fim, NULL)
	RETURN;
END