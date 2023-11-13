SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON 
GO
--******************************************************************************************************************************
--DESCRICAO:	Realiza insercao nas tabelas de produtos e Estoque no momento da criação de um produto.
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
CREATE OR ALTER PROCEDURE CriarProduto
(
	@CodigoDoProduto Varchar(40), 
	@NomeProduto Varchar (50),
	@CategoriaID INT,
	@Valor Decimal(15,2),
	@QuantidadeEmEstoque INT
)
AS 
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
	
		INSERT INTO Produtos (CodigoDoProduto,Nome,Valor,DataCriacao,CategoriaId,Status) 
		Values (@CodigoDoProduto,@NomeProduto,@Valor,GetDate(),@CategoriaID,1)


		INSERT INTO Estoque (Produto_ID,Codigo_Produto,ProdutoNome,Quantidade,DataEntrada) 
		SELECT ID,CodigoDoProduto,Nome,@QuantidadeEmEstoque,GetDate() From Produtos WHERE CodigoDoProduto = @CodigoDoProduto
	END TRY
	
	BEGIN CATCH 
		IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
	IF @@TRANCOUNT>0
	COMMIT TRANSACTION
END
GO