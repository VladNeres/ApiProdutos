IF EXISTS(SELECT * FROM sys.tables WHERE name = 'Estoque')
BEGIN

DECLARE @Contador INT  = 1
DECLARE @TotalRegistros INT;
SELECT @TotalRegistros = COUNT(*) FROM Produtos

WHILE @Contador <=  @TotalRegistros
	BEGIN

		INSERT INTO Estoque(produto_ID,Codigo_Produto,ProdutoNome,Quantidade,DataEntrada)
		SELECT ID,CodigoDoProduto, Nome, (RAND()*300), DataCriacao FROM Produtos WHERE ID = @Contador

		SET @Contador = @Contador +1 
	END
END
