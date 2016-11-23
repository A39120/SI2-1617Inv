USE AEnima
GO
IF OBJECT_ID('UpdateCliente') IS NOT NULL 
	DROP PROCEDURE UpdateCliente

GO
CREATE PROCEDURE UpdateCliente @id INT, @nome VARCHAR(31) = 'Cliente Final', @nif INT = NULL, @morada VARCHAR(100) = NULL
AS 
	--IF(@id IS NULL) RETURN -- Inserir mensagem de erro
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED -- ???
	BEGIN TRAN 
	UPDATE Cliente 
	SET 
		nome = @nome,
		nif = @nif,
		morada = @morada
	WHERE id = @id 
	COMMIT 