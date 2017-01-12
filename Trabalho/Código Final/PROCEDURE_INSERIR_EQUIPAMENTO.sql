USE AEnima 
IF OBJECT_ID('dbo.InserirEquipamentoComTipo') IS NOT NULL 
	DROP PROCEDURE dbo.InserirEquipamentoComTipo
IF OBJECT_ID('dbo.InserirEquipamento') IS NOT NULL 
	DROP PROCEDURE dbo.InserirEquipamento

GO
CREATE PROCEDURE dbo.InserirEquipamentoComTipo @tipo VARCHAR(31), @descr VARCHAR(255) = NULL, @descrTipo VARCHAR(255) = NULL
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN 
	IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo) 
		BEGIN
			INSERT INTO Tipo(nome, descr) VALUES (@tipo, @descrTipo)
		END
	INSERT INTO Equipamento(descr, tipo) VALUES (@descr, @tipo)
	COMMIT
	
GO
CREATE PROCEDURE dbo.InserirEquipamento @tipo VARCHAR(31), @descr VARCHAR(255) = NULL, @novoID INT OUTPUT
AS
	DECLARE @tmpTable TABLE (id INT)
	INSERT INTO Equipamento(descr, tipo) 
	OUTPUT INSERTED.eqId INTO @tmpTable
	VALUES (@descr, @tipo)

	SELECT @novoID = id FROM @tmpTable
GO

