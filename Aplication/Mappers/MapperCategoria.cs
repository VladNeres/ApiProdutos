using ConnectionSql.Dtos;
using Domain.ViewlModels;


namespace Aplication.Mappers
{
    public static class MapperCategoria
    {
        public static Categoria ParaCreateCategoriaDto(CreateCategoriaDto categoriaDto) =>
          new Categoria()
          {
                Nome = categoriaDto.Nome,
                DataCriacao = categoriaDto.DataCriacao,
                DataAlteracao = categoriaDto.DataAlteracao
          };

        

         public static Categoria ParaUpdateCategoriaDto(UpdateCategoriaDto updateCategoria) =>
            new Categoria()
            {
                Nome = updateCategoria.Nome,
                DataCriacao = updateCategoria.DataCriacao,
                DataAlteracao = updateCategoria.DataCriacao
            };
        public static ReadCategoriaDto ParaReadCategoriaDto(Categoria categoria) =>
          new ReadCategoriaDto() 
          { Nome = categoria.Nome, 
            DataCriacao = categoria.DataCriacao, 
            DataAlteracao = categoria.DataCriacao
          };

      
    }
}
