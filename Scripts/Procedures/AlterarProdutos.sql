SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--******************************************************************************************************************************
--DESCRICAO:	Realiza Alteração nas tabelas de produtos e Estoque no momento da criação de um produto.
--
--
--
-- PROJETO:		SistemaDeMercado 
-- DATA:			27/10/2023
--******************************************************************************************************************************
-- ALTERACAO:
--
--
--
-- DATA:
-----------------------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE AlterarProduto(
@ID INT, 
@nome Varchar(50),
@valor decimal(15,2),
@DataAlteracao DateTime,
@Status bit, 
@CategoriaID INT 
)
AS
BEGIN	
	BEGIN TRANSACTION
	BEGIN TRY
		UPDATE Produtos Set Nome = @nome, Valor = @valor,DataAlteracao = @DataAlteracao,Status = @Status, CategoriaId = @CategoriaID WHERE ID = @ID 

		UPDATE Estoque Set ProdutoNome = (Select Nome from produtos where ID = @ID) WHERE ID = @ID
	END TRY
		
		BEGIN CATCH
			IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION
			THROW;
		END CATCH
	
	IF @@TRANCOUNT > 0
	COMMIT TRANSACTION
END
GO