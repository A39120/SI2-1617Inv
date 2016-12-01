USE AEnima
GO
IF OBJECT_ID('dbo.ActualizarCliente') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarCliente

GO
CREATE PROCEDURE dbo.ActualizarCliente @id INT, @nome VARCHAR(31), @nif INT, @morada VARCHAR(100)
AS	
	IF(@id IS NULL) 
			THROW 50002, 'Id inválido', 1;
	IF(@id = 1) 
			THROW 50003, 'Não se pode alterar a informação do Cliente Final', 1; 
	IF(@nome IS NULL OR @nif IS NULL OR @morada IS NULL) 
			THROW 50004, 'Não se pode alterar a informação do Cliente com alguma informação nula', 1;
 
	UPDATE Cliente 
	SET 
		nome = @nome,
		nif = @nif,
		morada = @morada
	WHERE cId = @id 
GO 