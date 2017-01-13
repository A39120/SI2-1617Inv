USE AEnima 
IF OBJECT_ID('dbo.InserirPreco') IS NOT NULL 
	DROP PROCEDURE dbo.InserirPreco
	
GO
CREATE PROCEDURE dbo.InserirPreco @tipo VARCHAR(31), @valor FLOAT, @duracao TIME, @validade DATE
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN
		IF NOT EXISTS(SELECT nome FROM TipoView WHERE nome = @tipo)
			BEGIN
				ROLLBACK;
				THROW 50200, 'Tipo não existe', 1;
			END

		--Ve se o parametro tipo passado é nulo
		IF (@tipo IS NULL)
			BEGIN
				ROLLBACK;
				THROW 50201, 'Tipo não pode ser nulo', 1; 
			END

		--Ve se o parametro valor passado é nulo
		IF (@valor IS NULL)
			BEGIN
				ROLLBACK;
				THROW 50202, 'Valor não pode ser nulo', 1; 
			END

		-- Ve se o parametro duracao está a nulo
		IF (@duracao IS NULL)
			BEGIN
				ROLLBACK;
				THROW 50203, 'Duração não pode ser nula', 1; 
			END

		-- Ve se o parametro validade está a nulo
		IF (@validade IS NULL)
			BEGIN
				ROLLBACK;
				THROW 50204, 'Validade não pode ser nula', 1; 
			END
		
		--Se não tiver erros, insere na tabela preço (podem acontecer outros erros relacionados com FK)
		INSERT INTO Preco(tipo, valor, duracao, validade) VALUES(@tipo, @valor, @duracao, @validade)
	COMMIT
GO