using Domain.ViewlModels;

namespace ConnectionSql.RepositopriesInterfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> Buscarcategorias();
        Task<List<Categoria>> BuscarCategoria(int id);
        Task<int> CriarCategoria(Categoria categoria);
        Task<bool> VerificarSeExisteCategoria(string nome);
        Task<int> AtualizarCategoria(int id, Categoria categoria);
        Task<int> DeletarCategoria(int id);

    }
}
