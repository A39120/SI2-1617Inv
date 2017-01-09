USE AEnima;
GO
-- delete part
IF OBJECT_ID('dbo.ClienteView') IS NOT NULL
	DROP VIEW dbo.ClienteView
IF OBJECT_ID('dbo.AluguerView') IS NOT NULL
	DROP VIEW dbo.AluguerView
IF OBJECT_ID('dbo.TipoView') IS NOT NULL
	DROP VIEW dbo.TipoView
IF OBJECT_ID('dbo.EquipamentoDisponivelView') IS NOT NULL
	DROP VIEW dbo.EquipamentoDisponivelView

GO

-- create part
CREATE VIEW dbo.ClienteView AS -- view para mostrar apenas os clientes ainda válidos
SELECT cId, nif, nome, morada FROM Cliente WHERE valido = 1

GO

CREATE VIEW dbo.AluguerView AS -- view para mostrar apenas os alugueres a decorrer
SELECT serial as id, eqId as equipamento, empregado, cliente, data_inicio as dataInicio, data_fim as dataFim
FROM dbo.Aluguer a INNER JOIN dbo.AluguerDataFim adf ON (a.serial = adf.serial_adf)
WHERE deleted = 0

GO

CREATE VIEW dbo.EquipamentoDisponivelView AS
SELECT eqId, descr, tipo
FROM dbo.Equipamento
WHERE(valid = 1)

GO

CREATE VIEW dbo.TipoView AS -- view para mostrar apenas os Tipos para os quais existem Equipamentos desse Tipo (aka "Tipos válidos para aluguer")
SELECT t.*
FROM dbo.Tipo t INNER JOIN dbo.Equipamento e ON (t.nome = e.tipo AND e.valid = 1)

GO