using ConnectionSql.Dtos;
using Domain.ViewlModels;


namespace Aplication.Mappers
{
    public static class MapperCategoria
    {
        public static Categoria ParaCategoria(CreateCategoriaDto categoriaDto) =>
          new Categoria()
          {
              Nome = categoriaDto.Nome,
              DataCriacao = DateTime.Now
          };



        public static Categoria DeUpdateCategoriaDtoParaCategoria(UpdateCategoriaDto updateCategoria) =>
           new Categoria()
           {
               Nome = updateCategoria.Nome,
               DataAlteracao = DateTime.Now
           };

        public static ReadCategoriaDto ParaReadCategoriaDto(Categoria categoria)
        {
            if (categoria.DataAlteracao <= DateTime.MinValue)
            {
                return new ReadCategoriaDto()
                {
                    Nome = categoria.Nome,
                    DataCriacao = categoria.DataCriacao
                };
            }
            return new ReadCategoriaDto()
            {
                Nome = categoria.Nome,
                DataCriacao = categoria.DataCriacao,
                DataAlteracao = categoria.DataCriacao
            };
        }

        public static IEnumerable<ReadCategoriaDto> ParaListaReadCategoriaDto(IEnumerable<Categoria> categoria)
        {
            
            foreach (Categoria c in categoria)
            {
                if(c.DataAlteracao > DateTime.MinValue )
                yield return new ReadCategoriaDto() { Nome = c.Nome, DataAlteracao = c.DataAlteracao, DataCriacao = c.DataCriacao };
                else yield return new ReadCategoriaDto() { Nome =c.Nome , DataCriacao = c.DataCriacao };
            }


        }
    }
}
