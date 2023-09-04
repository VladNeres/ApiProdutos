using Domain.ViewlModels;

namespace ConnectionSql.RepositopriesInterfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarTodasAscategorias();
        Task<Categoria> CriarCategoria(Categoria categoria);
        Task<Categoria> BuscarCategoriasPorId(int id);
    }
}
