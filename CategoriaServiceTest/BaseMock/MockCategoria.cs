using Aplication.Mappers;
using ConnectionSql.Dtos;
using Domain.Messages;
using Domain.ViewlModels;

namespace Teste.BaseMock;

public static class MockCategoria
{

    public static Categoria CategoriaCompleta()
    {
        return new Categoria { ID = 1, Nome = "Teste", DataCriacao = DateTime.Now, DataAlteracao = DateTime.Now.AddMinutes(5) };
    }

    public static MensagemBase<Categoria> MensageBaseCategoriaCompleta()
    {
        Categoria categoria = new Categoria { ID = 1, Nome = "Teste", DataCriacao = DateTime.Now, DataAlteracao = DateTime.Now.AddMinutes(5) };
        return new MensagemBase<Categoria>()
        {
            Message = "Teste",
            Object = categoria,
            StatusCode = 200
        };
    }


    public static UpdateCategoriaDto UpdateCategoria()
    {
        return new UpdateCategoriaDto { Nome = "Teste" };
    }

    public static CreateCategoriaDto CreateCategoriaDto()
    {
        return new CreateCategoriaDto { Nome = "Teste" };
    }

    public static MensagemBase<IEnumerable<ReadCategoriaDto>> ListaReadCategoriaDto()
    {
        var listaCategoria = new List<Categoria>
        {
            new Categoria
            {
                Nome = "Teste",
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now.AddMinutes(20),
                Produtos = new List<Produto>
                {
                    new Produto()
                    {
                         Nome = "ProdutoTeste1",
                         CodigoProduto = Guid.NewGuid(),
                         DataSaida = DateTime.Now
                    }
                }

            },
            new Categoria
            {
                Nome = "Teste1",
                DataAlteracao = DateTime.Now.AddDays(1),
                DataCriacao = DateTime.Now.AddDays(2),
                 Produtos = new List<Produto>
                 {
                     new Produto()
                     {
                         Nome = "ProdutoTeste",
                         CodigoProduto = Guid.NewGuid(),
                         DataSaida = DateTime.Now
                     }
                 }
            }
        };

        var response = MapperCategoria.ParaListaReadCategoriaDto(listaCategoria);

        return new MensagemBase<IEnumerable<ReadCategoriaDto>>
        {
            Message = "Teste",
            Object = response,
            StatusCode = 200,
        };
    }


    public static List<Categoria> ListaDeCategorias()
    {
        return new List<Categoria>
        {
           new Categoria()
           {
               ID = 1,
               Nome = "Teste",
               DataAlteracao = DateTime.Now,
               DataCriacao = DateTime.Now.AddMinutes(20),
               Produtos = new List<Produto>
                 {
                     new Produto()
                     {
                         Nome = "ProdutoTeste",
                         CodigoProduto = Guid.NewGuid(),
                         DataSaida = DateTime.Now
                     }
                 }
           },
           new Categoria()
           {
               ID = 2,
               Nome = "Teste2",
               DataAlteracao = DateTime.Now,
               DataCriacao = DateTime.Now.AddMinutes(20),
               Produtos = new List<Produto>
                 {
                     new Produto()
                     {
                         Nome = "ProdutoTeste",
                         CodigoProduto = Guid.NewGuid(),
                         DataSaida = DateTime.Now
                     }
                 }
           }
        };
    }


}

