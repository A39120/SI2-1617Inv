USE AEnima;
IF OBJECT_ID('dbo.RemoverPreco') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverPreco
GO

CREATE PROCEDURE dbo.RemoverPreco @tipo VARCHAR(31), @valor FLOAT, @duracao TIME, @validade DATE
AS
	BEGIN TRAN
		IF NOT EXISTS(SELECT nome FROM Tipo WHERE nome = @tipo)
			BEGIN
				ROLLBACK
				THROW 50205, 'Tipo não existe', 1;
			END
		ELSE
			DELETE FROM Preco WHERE tipo = @tipo AND valor = @valor AND duracao = @duracao AND validade = @validade
	COMMIT