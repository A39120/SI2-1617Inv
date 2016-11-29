USE AEnima;
GO
-- delete part
IF OBJECT_ID('dbo.ClienteView') IS NOT NULL
	DROP VIEW dbo.ClienteView

GO
-- create part
CREATE VIEW dbo.ClienteView AS -- view para mostrar apenas os clientes ainda v�lidos
SELECT cId, nif, nome, morada FROM Cliente WHERE valido = 1

GO

CREATE VIEW dbo.AluguerView AS -- view para mostrar apenas os alugueres a decorrer
SELECT serial, eqId, empregado, cliente, data_inicio
FROM dbo.Aluguer
WHERE deleted = 0