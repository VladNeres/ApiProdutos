using Aplication.Mappers.mapperProduto;
using ConnectionSql.Dtos;
using ConnectionSql.Dtos.ProdutosDtos;
using Domain.ViewlModels;
using System.Linq.Expressions;

namespace Aplication.Mappers
{
    public static class MapperCategoria
    {
        public static Categoria ParaCategoria(this CreateCategoriaDto categoriaDto) =>
          new Categoria()
          {
              Nome = categoriaDto.Nome
          };



        public static Categoria DeUpdateCategoriaDtoParaCategoria(this UpdateCategoriaDto updateCategoria) =>
           new Categoria()
           {
               Nome = updateCategoria.Nome,
               DataAlteracao = DateTime.Now
           };

        public static ReadCategoriaDto ParaReadCategoriaDto(this Categoria categoria)
        {
            List<ReadProdutoDto> listaReadProdutos = new List<ReadProdutoDto>();
            if(categoria.Produtos != null) 
            foreach(var p in categoria.Produtos)
            {
                listaReadProdutos.Add(p.ParaReadProdutoDto());
            }

            return new ReadCategoriaDto(categoria.Nome, categoria.DataCriacao, categoria.DataAlteracao, listaReadProdutos);
        }


        public static IEnumerable<ReadCategoriaDto> ParaListaReadCategoriaDto(IEnumerable<Categoria> categoria)
        {
            List<ReadCategoriaDto> lista = new List<ReadCategoriaDto>();
            foreach (Categoria c in categoria)
            {
                lista.Add(c.ParaReadCategoriaDto());
            }
            return lista;
        }


    }
}
