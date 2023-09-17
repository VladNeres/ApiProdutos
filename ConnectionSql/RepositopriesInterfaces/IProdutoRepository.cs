using Domain.ViewlModels;


namespace ConnectionSql.RepositopriesInterfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> AtualizarProduto(Produto produto);
        Task<Produto> CriarProduto(Produto produto);
        Task<List<Produto>> BuscarPedidoCompleto();
        Task<Produto> BuscarPorId(int id);

    }
}
