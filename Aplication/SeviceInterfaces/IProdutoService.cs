using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Messages;
using Domain.Models;
using Domain.ViewlModels;


namespace Aplication.SeviceInterfaces
{
    public interface IProdutoService
    {
        Task<MensagemBase<List<ReadProdutoDto>>> BuscarPedidos();
        Task<MensagemBase<ReadProdutoDto>> BuscarProdutosPorId(Guid id);
        Task<MensagemBase<Produto>> CriarProduto(CreateProdutoDto produtoDto);
        Task<MensagemBase<UpdateProdutoDto>> AtualizarPedido(Guid id, UpdateProdutoDto produtoDto);
        Task<MensagemBase<UpdateProdutoSimplificado>> AtualizarPedidoSimplificado(UpdateProdutoSimplificado produtoDto);
        Task<MensagemBase<bool>> DeletarProduto(Guid id);
        Task<MensagemBase<Paginacao<List<ReadProdutoDto>>>> BuscarPedidosPaginada(int currentPge, int pageSize);


    }
}
