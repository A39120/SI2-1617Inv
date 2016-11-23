USE AEnima
GO
IF OBJECT_ID('DeleteCliente') IS NOT NULL 
	DROP PROCEDURE DeleteCliente

GO
CREATE PROC DeleteCliente @id INT
AS 
	DELETE FROM Cliente WHERE id = @id	-- Isto fica inativo ou delete???