USE AEnima 
IF OBJECT_ID('dbo.InserirPreco') IS NOT NULL 
	DROP PROCEDURE dbo.InserirPreco
	
CREATE PROCEDURE dbo.InserirPreco @tipo VARCHAR(31), @valor FLOAT, @duracao TIME, @validade DATE
AS
	BEGIN TRAN
		IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo)
			BEGIN
				ROLLBACK
				THROW 50200, 'Tipo não existe', 1;
			END
		ELSE
		BEGIN
			IF IsNull(tipo)
				BEGIN
					ROLLBACK
					THROW 50201, 'Tipo não pode ser nulo', 1; 
				END
			ELSE IF IsNull(valor)
				BEGIN
					ROLLBACK
					THROW 50202, 'Valor não pode ser nulo', 1; 
				END
			ELSE IF IsNull(duracao)
				BEGIN
					ROLLBACK
					THROW 50203, 'Duração não pode ser nula', 1; 
				END
			ELSE IF IsNull(validade)
				BEGIN
					ROLLBACK
					THROW 50204, 'Validade não pode ser nula', 1; 
				END
			
			INSERT INTO Preco(tipo, valor, duracao, validade) VALUES(@tipo, @valor, @duracao, @validade)
		END
	COMMIT
GO