USE AEnima 
IF OBJECT_ID('dbo.InserirCliente') IS NOT NULL 
	DROP PROCEDURE dbo.InserirCliente

GO
CREATE PROCEDURE dbo.InserirCliente 
	@nome VARCHAR(31), 
	@nif INT, 
	@morada VARCHAR(100), 
	@idCliente INT output
AS 
	IF(@nome IS NOT NULL AND @nif IS NOT NULL AND @morada IS NOT NULL)
	BEGIN
			DECLARE @clienteTable TABLE (id INT)
			INSERT INTO Cliente(nome, nif, morada) 
				OUTPUT INSERTED.cId INTO @clienteTable
				VALUES (@nome, @nif, @morada);
			SELECT @idCliente = id FROM @clienteTable;
	END
	ELSE
		THROW 50001, 'Não se pode inserir um cliente sem alguns valores', 1; -- xact on auto aborts

GO
--exec dbo.InserirCliente 'João Lopes', 250668122, 'Avn. Isel'
--exec dbo.InserirCliente NULL, 1, 'a'