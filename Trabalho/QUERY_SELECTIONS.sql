USE AEnima
SELECT * FROM Tipo 
SELECT * FROM Equipamento
SELECT * FROM Cliente
SELECT * FROM Empregado
SELECT * FROM Preco
SELECT * FROM Aluguer al INNER JOIN AluguerPrecoDuracao apd ON (al.serial = serial_apd)
	INNER JOIN AluguerDataFim adf ON(serial = serial_adf)


SELECT * FROM TipoPromocao

SELECT * FROM Promocao p INNER JOIN PromocaoDesconto pd ON(p.pId = pd.pId)
SELECT * FROM Promocao p INNER JOIN PromocaoTemporal pt ON(p.pId = pt.pId)

SELECT * FROM Equipamento eq INNER JOIN TipoPromocao tp ON(eq.tipo = tp.tipo)
	INNER JOIN Promocao p ON(p.pId = tp.pId)