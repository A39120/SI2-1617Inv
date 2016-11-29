USE AEnima
GO
IF OBJECT_ID('dbo.ActualizarPreco') IS NOT NULL 
	DROP PROCEDURE dbo.ActualizarPreco

GO
CREATE PROCEDURE dbo.ActualizarPreco 
@tipo VARCHAR(31), @valor FLOAT, @duracao TIME, @validade DATE, 
				   @novovalor FLOAT, @novaduracao TIME, @novavalidade DATE
AS
	BEGIN TRAN
	IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo)
		BEGIN
			ROLLBACK
			THROW 50206, 'Tipo n�o existe', 1;
		END
	ELSE
		IF NOT EXISTS(SELECT * FROM Preco WHERE tipo = @tipo AND valor = @valor AND duracao = @duracao AND validade = @validade)
			THROW 50207, 'Pre�o n�o existe', 1;
		ELSE
			BEGIN
			IF(@novovalor IS NULL)
				BEGIN
					ROLLBACK
					THROW 50208, 'Novo valor n�o pode ser nulo', 1;
				END
			ELSE IF(@novaduracao IS NULL) 
				BEGIN
					ROLLBACK
					THROW 50209, 'Nova dura��o n�o pode ser nula', 1; 
				END
			ELSE IF(@novavalidade IS NULL) 
				BEGIN
					ROLLBACK
					THROW 50210, 'Nova validade n�o pode ser nula', 1;
				END
			ELSE
				BEGIN
					BEGIN TRAN -- para garantir atomicidade na "actualiza��o"
						--apagar velho
						DELETE FROM Preco WHERE tipo = @tipo AND valor = @valor AND duracao = @duracao AND validade = @validade
						--inserir novo
						INSERT INTO Preco(tipo, valor, duracao, validade) VALUES(@tipo, @novovalor, @novaduracao, @novavalidade)
					COMMIT
				END
			END
	COMMIT
GO 