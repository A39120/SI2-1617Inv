USE AEnima;
GO
-- delete part
IF OBJECT_ID('dbo.ClienteView') IS NOT NULL
	DROP VIEW dbo.ClienteView
IF OBJECT_ID('dbo.AluguerView') IS NOT NULL
	DROP VIEW dbo.AluguerView
IF OBJECT_ID('dbo.TipoView') IS NOT NULL
	DROP VIEW dbo.TipoView

GO

-- create part
CREATE VIEW dbo.ClienteView AS -- view para mostrar apenas os clientes ainda válidos
SELECT cId, nif, nome, morada FROM Cliente WHERE valido = 1

GO

CREATE VIEW dbo.AluguerView AS -- view para mostrar apenas os alugueres a decorrer
SELECT serial, eqId, empregado, cliente, data_inicio
FROM dbo.Aluguer
WHERE deleted = 0

GO


CREATE VIEW dbo.EquipamentoDisponivel AS
SELECT eqId, descr, tipo
FROM dbo.Equipamento
WHERE(in_use = 1)

GO

CREATE VIEW dbo.TipoView AS -- view para mostrar apenas os Tipos para os quais existem Equipamentos desse Tipo (aka "Tipos válidos para aluguer")
SELECT t.*
FROM dbo.Tipo t INNER JOIN dbo.Equipamento e ON (t.nome = e.tipo)

GO