using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Messages;
using Domain.ViewlModels;


namespace Aplication.SeviceInterfaces
{
    public interface IProdutoService
    {
        Task<MensagemBase<List<ReadProdutoDto>>> BuscarPedidos();
        Task<MensagemBase<ReadProdutoDto>> BuscarPedidosPorId(int id);
        Task<MensagemBase<Produto>> CriarProduto(CreateProdutoDto produtoDto);
        Task<MensagemBase<UpdateProdutoDto>> AtualizarPedido(int id, UpdateProdutoDto produtoDto);
        Task<MensagemBase<UpdateProdutoSimplificado>> AtualizarPedidoSimplificado(int id, UpdateProdutoSimplificado produtoDto);
        Task<MensagemBase<bool>> DeletarProduto(int id);



    }
}
