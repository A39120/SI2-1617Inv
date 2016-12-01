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
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN
	IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo) 
		INSERT INTO Tipo(nome, descr) VALUES (@tipo, @descrTipo);

	UPDATE Equipamento SET 
		descr = @descr, 
		tipo = @tipo
	WHERE eqId = @id AND in_use = 1

	COMMIT
GO

CREATE PROCEDURE dbo.ActualizarEquipamento 
	@id INT, 
	@tipo VARCHAR(31), 
	@descr VARCHAR(255) = NULL
AS
	-- São lançadas exceções se algum dos tipos acima for nulo ou não existir na tabela
	UPDATE Equipamento SET 
		descr = @descr, 
		tipo = @tipo
	WHERE eqId = @id AND in_use = 1
GO