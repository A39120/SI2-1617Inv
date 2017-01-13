USE AEnima;
IF OBJECT_ID('dbo.RemoverPreco') IS NOT NULL 
	DROP PROCEDURE dbo.RemoverPreco
GO

CREATE PROCEDURE dbo.RemoverPreco @tipo VARCHAR(31), @valor FLOAT, @duracao TIME, @validade DATE
AS
	DELETE FROM Preco WHERE tipo = @tipo AND valor = @valor AND duracao = @duracao AND validade = @validade