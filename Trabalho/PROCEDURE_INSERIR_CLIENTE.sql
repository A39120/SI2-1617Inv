USE AEnima 
IF OBJECT_ID('dbo.InserirCliente') IS NOT NULL 
	DROP PROCEDURE dbo.InserirCliente

GO
CREATE PROCEDURE dbo.InserirCliente @nome VARCHAR(31), @nif INT, @morada VARCHAR(100)
AS 
	IF(@nome IS NOT NULL AND @nif IS NOT NULL AND @morada IS NOT NULL)
		INSERT INTO Cliente(nome, nif, morada) VALUES (@nome, @nif, @morada);
	ELSE THROW 50001, 'Não se pode inserir um cliente sem alguns valores', 1;

GO
--exec dbo.InserirCliente 'João Lopes', 250668122, 'Avn. Isel'
--exec dbo.InserirCliente NULL, 1, 'a'