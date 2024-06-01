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
               Nome = "ProdutoTeste",
               CodigoDoProduto = Guid.NewGuid(),
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
                    CodigoDoProduto = Guid.NewGuid(),
                    Valor = 123,
                    Status = true,
                    CategoriaId = 1,
                    DataEntrada = DateTime.Now
                },
                new Produto()
                {
                    
                    Nome = "ProdutoTeste2",
                    CodigoDoProduto = Guid.NewGuid(),
                    Valor = 123,
                    Status = true,
                    CategoriaId = 1,
                    DataEntrada = DateTime.Now
                }

            };
        }
       
    }
}
