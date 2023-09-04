using ConnectionSql.Dtos;
using Domain.ViewlModels;


namespace Aplication.interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<ReadCategoriaDto>> BuscarTodasCategorias();
        Task<ReadCategoriaDto> BuscarCategoriasPorId(int id);
        Task<Categoria> CriarCategoria(CreateCategoriaDto categoriaDto);
    }
}
