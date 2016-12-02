--TEST E: (i) Efectuar alterações de preçário;

USE AEnima
exec InserirEquipamentoComTipo 'Tipo 1' 
exec InserirPreco 'Tipo 1' , 1, '00:30:00', '2020-10-20 13:00:00'
IF NOT EXISTS(SELECT * FROM Preco WHERE tipo = 'Tipo 1' )
	RAISERROR ('Test Error 1: Preco was not created.', 10,  1);

exec ActualizarPreco 'Tipo 1' , 1, '00:30:00', '2020-10-20 13:00:00', 2, '00:30:00', '2020-10-20 13:00:00'
IF NOT EXISTS(SELECT * FROM Preco WHERE tipo = 'Tipo 1'  AND valor = 2 AND duracao = '00:30:00')
	RAISERROR ('Test Error 2: Preco was not updated.', 10,  1);

exec RemoverPreco 'Tipo 1', 2, '00:30:00', '2020-10-20 13:00:00'
IF EXISTS(SELECT * FROM Preco WHERE tipo = 'Tipo 1'  AND valor = 2 AND duracao = '00:30:00')
	RAISERROR ('Test Error 3: Preco was not removed.', 10,  1);