using ConnectionSql.Dtos.ProdutosDtos;
using Domain.ViewlModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ItemServiceHttpClient
{
    public interface IEstoqueService
    {
        [Patch("/AtualizarParcial")]
        Task <HttpResponseMessage> AtualizarEstoque(UpdateProdutoSimplificado produto);
    }
}
