using ConnectionSql.Dtos.ProdutosDtos;
using Refit;

namespace Aplication.ItemServiceHttpClient
{
    public interface IEstoqueService
    {
        [Patch("/Estoque/AtualizarParcial")]
        Task<HttpResponseMessage> AtualizarEstoque(UpdateProdutoSimplificado produto);
    }
}
