using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Messages;
using Domain.ViewlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.SeviceInterfaces
{
    public interface IProdutoService
    {
        Task<MensagemBase<List<Produto>>> BuscarPedidos();
        Task<MensagemBase<Produto>> BuscarPedidosPorId(int id);
        Task<MensagemBase<Produto>> CriarProduto(CreateProdutoDto produtoDto);
        Task<MensagemBase<Produto>> CriarProduto(UpdateProdutoDto produtoDto);
    }
}
