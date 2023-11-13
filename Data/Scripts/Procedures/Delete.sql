SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON 
GO
--******************************************************************************************************************************
--DESCRICAO:	Realiza a deleção nas tabelas de produtos e Estoque no momento da criação de um produto.
--
--
--
-- PROJETO:		SistemaDeMercado 
-- DATA:			20/10/2023
--******************************************************************************************************************************
-- ALTERACAO:
--
--
--
-- DATA:
-----------------------------------------------------------------------------------------------------------------------------------
CREATE  OR ALTER PROCEDURE DeleteProduto(
@ID INT)
AS
BEGIN	
	BEGIN TRANSACTION
	BEGIN TRY
		DELETE Estoque  WHERE ID = @ID
		DELETE Produtos WHERE ID = @ID 

	END TRY
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			COMMIT
			
		END CATCH
	
	IF @@TRANCOUNT > 0
	COMMIT
END