using ConnectionSql.Dtos.ProdutosDtos;
using Domain.ViewlModels;


namespace ConnectionSql.RepositopriesInterfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscarPedidoCompleto();
        Task<Produto> BuscarPorId(int id);
        Task<Produto> CriarProduto(Produto produto);
        Task<bool> AtualizarProduto(int id, Produto produto);
        Task<bool> AtualizarProdutoSimplificado(int id, Produto produto);
        Task<bool> DeleteProduto(int id);


    }
}
