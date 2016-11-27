SELECT * FROM Tipo 
SELECT * FROM Equipamento
SELECT * FROM Cliente
SELECT * FROM Empregado
SELECT * FROM Preco

SELECT * FROM TipoPromocao
SELECT * FROM Promocao p INNER JOIN PromocaoDesconto pd ON(p.pId = pd.pId)
SELECT * FROM Promocao p INNER JOIN PromocaoTemporal pt ON(p.pId = pt.pId)

