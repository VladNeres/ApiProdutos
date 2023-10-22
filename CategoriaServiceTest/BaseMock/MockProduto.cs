using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Models;
using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.BaseMock
{
    public static class MockProduto
    {
        public static Produto ProdutoCompleto()
        {
           return new Produto()
           {
               ID = 1,
               Nome = "ProdutoTeste",
               CodigoDoProduto = Guid.NewGuid().ToString(),
               Valor = 123,
               Status = true,
               CategoriaId = 1,
               DataCriacao = DateTime.Now
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
                    ID = 1,
                    Nome = "ProdutoTeste",
                    CodigoDoProduto = Guid.NewGuid().ToString(),
                    Valor = 123,
                    Status = true,
                    CategoriaId = 1,
                    DataCriacao = DateTime.Now
                },
                new Produto()
                {
                    ID = 2,
                    Nome = "ProdutoTeste2",
                    CodigoDoProduto = Guid.NewGuid().ToString(),
                    Valor = 123,
                    Status = true,
                    CategoriaId = 1,
                    DataCriacao = DateTime.Now
                }

            };
        }
       
    }
}
