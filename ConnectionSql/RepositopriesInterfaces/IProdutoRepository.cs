using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Models;
using Domain.ViewlModels;
using System.Data;

namespace ConnectionSql.RepositopriesInterfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscarPedidoCompleto();
        Task<Produto> BuscarPorId(int id);
        Task<int> CriarProduto(Produto produto, int quantidadeEmEstoque);
        Task<bool> AtualizarProduto(int id, Produto produto);
        Task<bool> AtualizarProdutoSimplificado(int id, Produto produto);
        Task<bool> DeleteProduto(int id);

        Task<Paginacao<List<Produto>>> BuscarPedidoPaginada(int currentPge, int pageSize);


    }
}
