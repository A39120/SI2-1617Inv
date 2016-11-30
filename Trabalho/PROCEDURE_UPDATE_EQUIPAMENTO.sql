USE AEnima 
IF OBJECT_ID('dbo.ActualizarEquipamentoComNovoTipo') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarEquipamentoComNovoTipo
IF OBJECT_ID('dbo.ActualizarEquipamento') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarEquipamento

GO
CREATE PROCEDURE dbo.ActualizarEquipamentoComNovoTipo 
	@id INT, 
	@tipo VARCHAR(31), 
	@descr VARCHAR(255) = NULL, 
	@descrTipo VARCHAR(255) = NULL
AS
	BEGIN TRAN -- Necessario transa��o (2 escritas)
	IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo) 
		INSERT INTO Tipo(nome, descr) VALUES (@tipo, @descrTipo);

	UPDATE Equipamento SET 
		descr = @descr, 
		tipo = @tipo
	WHERE eqId = @id
	COMMIT
GO

CREATE PROCEDURE dbo.ActualizarEquipamento 
	@id INT, 
	@tipo VARCHAR(31), 
	@descr VARCHAR(255) = NULL
AS
	-- S�o lan�adas exce��es se algum dos tipos acima for nulo ou n�o existir na tabela
	UPDATE Equipamento SET 
		descr = @descr, 
		tipo = @tipo
	WHERE eqId = @id
GO