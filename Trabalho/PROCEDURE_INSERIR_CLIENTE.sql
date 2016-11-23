USE AEnima 
IF OBJECT_ID('InserirCliente') IS NOT NULL 
	DROP PROCEDURE InserirCliente

GO
CREATE PROCEDURE InserirCliente @nome VARCHAR(31) = 'Cliente Final', @nif INT = NULL, @morada VARCHAR(100) = NULL
AS 
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED -- So uma operacao de escrita
	BEGIN TRAN
	INSERT INTO Cliente(nome, nif, morada) VALUES (@nome, @nif, @morada);
	COMMIT