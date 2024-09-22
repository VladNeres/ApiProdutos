using Domain.Models;
using Domain.ViewlModels;

namespace ConnectionSql.RepositopriesInterfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscarPedidoCompleto();
        Task<Produto> BuscarPorId(Guid id);
        Task<int> CriarProduto(Produto produto);
        Task<bool> AtualizarProduto(Guid id, Produto produto);
        Task<bool> AtualizarProdutoSimplificado(Guid codigo, Produto produto);
        Task<bool> DeleteProduto(Guid id);

        Task<Paginacao<List<Produto>>> BuscarPedidoPaginada(int currentPge, int pageSize);


    }
}
