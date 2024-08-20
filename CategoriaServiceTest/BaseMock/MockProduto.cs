using ConnectionSql.Dtos.ProdutosDtos;
using Domain.ViewlModels;

namespace Teste.BaseMock
{
    public static class MockProduto
    {
        public static Produto ProdutoCompleto()
        {
            return new Produto()
            {
                Nome = "ProdutoTeste",
                CodigoProduto = Guid.NewGuid(),
                Valor = 123,
                Status = true,
                CategoriaId = 1,
                DataEntrada = DateTime.Now
            };
        }

        public static CreateProdutoDto CreateProdutoDto()
        {
            return new CreateProdutoDto()
            {
                Nome = "CreateTeste",
                CategoriaId = 1,
                Status = true,
                QuantidadeEmEstoque = 1,
                Valor = 1234
            };
        }

        public static List<Produto> GerarListaDeProdutos()
        {
            return new List<Produto>()
            {
                new Produto()
                {

                    Nome = "ProdutoTeste",
                    CodigoProduto = Guid.Parse("CA32D422-50FB-4964-8C87-061362A2D834"),
                    Valor = 123,
                    Status = true,
                    CategoriaId = 1,
                    DataEntrada = DateTime.Now
                },
                new Produto()
                {

                    Nome = "ProdutoTeste2",
                    CodigoProduto = Guid.Parse("CA32D422-50FB-4964-8C87-061362A2D834"),
                    Valor = 123,
                    Status = true,
                    CategoriaId = 1,
                    DataEntrada = DateTime.Now
                }

            };
        }

    }
}
