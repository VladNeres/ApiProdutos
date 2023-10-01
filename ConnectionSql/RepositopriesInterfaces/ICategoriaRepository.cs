using ConnectionSql.Dtos;
using Domain.Messages;
using Domain.ViewlModels;

namespace ConnectionSql.RepositopriesInterfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> BuscarTodasAscategorias();
        Task<List<Categoria>> BuscarCategoriasPorId(int id);
        Task<int> CriarCategoria(Categoria categoria);
        Task<bool> VerificarSeExisteCategoria(string nome);
        Task<int> AtualizarCategoria(int id, Categoria categoria);
        Task<int> DeletarCategoria(int id);

    }
}
