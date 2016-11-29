USE AEnima;
GO
-- delete part
IF OBJECT_ID('dbo.ClienteView') IS NOT NULL
	DROP VIEW dbo.ClienteView

GO
-- create part
CREATE VIEW dbo.ClienteView AS -- view para mostrar apenas os clientes ainda válidos
SELECT cId, nif, nome, morada FROM Cliente WHERE valido = 1

--SELECT * from ClienteView