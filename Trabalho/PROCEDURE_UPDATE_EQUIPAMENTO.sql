USE AEnima 
IF OBJECT_ID('dbo.ActualizarEquipamentoComNovoTipo') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarEquipamentoComNovoTipo
IF OBJECT_ID('dbo.ActualizarEquipamento') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarEquipamento

GO
CREATE PROCEDURE dbo.ActualizarEquipamentoComNovoTipo @id INT, @tipo VARCHAR(31), @descr VARCHAR(255) = NULL, @descrTipo VARCHAR(255) = NULL
AS
	BEGIN TRAN 
	IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo) 
	BEGIN
		INSERT INTO Tipo(nome, descr) VALUES (@tipo, @descrTipo)
	END
	UPDATE Equipamento SET 
		descr = @descr, 
		tipo = @tipo
	WHERE eqId = @id
	COMMIT
GO

CREATE PROCEDURE dbo.ActualizarEquipamento @id INT, @tipo VARCHAR(31), @descr VARCHAR(255) = NULL
AS
	UPDATE Equipamento SET 
		descr = @descr, 
		tipo = @tipo
	WHERE eqId = @id

GO
exec dbo.ActualizarEquipamento 2, 'Tenda', ''   --Tipo existe
exec dbo.ActualizarEquipamento 3, ''		    --Tipo não existente
exec dbo.ActualizarEquipamentoComNovoTipo 4, 'Paraquedas', 'Partido', 'fasfas' 