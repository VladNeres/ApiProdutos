using Aplication.ItemServiceHttpClient;
using Aplication.Mappers.mapperProduto;
using Aplication.SeviceInterfaces;
using ConnectionSql.Dtos.ProdutosDtos;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;
using Domain.Messages;
using Domain.Models;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Http;

namespace Aplication.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRespository;
    private readonly IDataTableToBulk _dataTableToBulk;
    private readonly IEstoqueService _estoqueService;
    public ProdutoService(IProdutoRepository produtoRespository, IDataTableToBulk dataTableToBulk, IEstoqueService estoqueService)
    {
        _produtoRespository = produtoRespository;
        this._dataTableToBulk = dataTableToBulk;
        _estoqueService = estoqueService;
    }


    public async Task<MensagemBase<Paginacao<List<ReadProdutoDto>>>> BuscarPedidosPaginada(int currentPge, int pageSize)
    {

        var produtos = await _produtoRespository.BuscarPedidoPaginada(currentPge, pageSize);

        var response = MapperProduto.ParaPaginacao(produtos);
        if (response.Data.Count == 0 || !response.Data.Any())
            return new MensagemBase<Paginacao<List<ReadProdutoDto>>>()
            {
                Message = "Lista vazia",
                StatusCode = StatusCodes.Status204NoContent
            };

        return new MensagemBase<Paginacao<List<ReadProdutoDto>>>()
        {
            Object = response,
            Message = "Busca realizada com sucesso!",
            StatusCode = StatusCodes.Status200OK
        };
    }

    public async Task<MensagemBase<List<ReadProdutoDto>>> BuscarPedidos()
    {

        var produtos = await _produtoRespository.BuscarPedidoCompleto();
        var response = produtos.ParaListReadProdutoDto();
        if (response.Count == 0 || !response.Any())
            return new MensagemBase<List<ReadProdutoDto>>()
            {
                Message = "Lista vazia",
                StatusCode = StatusCodes.Status204NoContent
            };


        return new MensagemBase<List<ReadProdutoDto>>()
        {
            Object = response,
            StatusCode = StatusCodes.Status200OK
        };
    }

    public async Task<MensagemBase<ReadProdutoDto>> BuscarProdutosPorId(Guid id)
    {
        var response = await _produtoRespository.BuscarPorId(id);
        var readDto = MapperProduto.ParaReadProdutoDto(response);

        if (response == null)
            return new MensagemBase<ReadProdutoDto>()
            {
                Message = "Pedido não encontrado",
                StatusCode = StatusCodes.Status204NoContent
            };
        return new MensagemBase<ReadProdutoDto>()
        {
            Object = readDto,
            StatusCode = StatusCodes.Status200OK
        };
    }

    public async Task<MensagemBase<Produto>> CriarProduto(CreateProdutoDto produtoDto)
    {
        var existeNaBase = await _produtoRespository.BuscarPedidoCompleto();
        if (existeNaBase.FirstOrDefault(p => p.Nome == produtoDto.Nome) != null)
        {
            return new MensagemBase<Produto>()
            {
                Message = "O produto ja existe",
                Object = produtoDto.CreateParaProduto(),
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
        }

        var produto = MapperProduto.CreateParaProduto(produtoDto);
        await _produtoRespository.CriarProduto(produto, produtoDto.QuantidadeEmEstoque);
        return new MensagemBase<Produto>()
        {
            Message = "Produto criado com sucesso!",
            Object = produto,
            StatusCode = StatusCodes.Status201Created
        };
    }


    public async Task<MensagemBase<UpdateProdutoDto>> AtualizarPedido(Guid id, UpdateProdutoDto produtoDto)
    {
        var existeNaBase = await _produtoRespository.BuscarPedidoCompleto();
        if (existeNaBase.FirstOrDefault(p => p.Nome == produtoDto.Nome) != null)
        {
            return new MensagemBase<UpdateProdutoDto>()
            {
                Message = "O produto ja existe",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        if (existeNaBase.FirstOrDefault(p => p.CodigoProduto.Equals(id)) == null)
        {
            return new MensagemBase<UpdateProdutoDto>()
            {
                Message = "O produto não foi encontrado",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        var produto = MapperProduto.UpdateParaProduto(produtoDto);
        await _produtoRespository.AtualizarProduto(id, produto);
        return new MensagemBase<UpdateProdutoDto>()
        {
            Message = "Produto atualizado com sucesso!",
            Object = produtoDto,
            StatusCode = StatusCodes.Status204NoContent
        };
    }


    public async Task<MensagemBase<UpdateProdutoSimplificado>> AtualizarPedidoSimplificado(UpdateProdutoSimplificado produtoDto)
    {
        var existeNaBase = await _produtoRespository.BuscarPedidoCompleto();
        if (existeNaBase.FirstOrDefault(p => p.Nome.ToUpper() == produtoDto.Nome.ToUpper()) != null)
        {
            return new MensagemBase<UpdateProdutoSimplificado>()
            {
                Message = "O produto ja existe",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        if (existeNaBase.FirstOrDefault(p => p.CodigoProduto.Equals(produtoDto.CodigoProduto)) == null)
        {
            return new MensagemBase<UpdateProdutoSimplificado>()
            {
                Message = "O produto não foi encontrado",
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
        }
        var response = await _estoqueService.AtualizarEstoque(produtoDto);
        if (!response.IsSuccessStatusCode)
        {
            return new MensagemBase<UpdateProdutoSimplificado>()
            {
                Message = "Ops algo deu errado, não foi possivel realizar a alteração do nome no estoque!",
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
        var produto = MapperProduto.UpdateSimplificadoParaProduto(produtoDto);
        await _produtoRespository.AtualizarProdutoSimplificado(produtoDto.CodigoProduto, produto);
        return new MensagemBase<UpdateProdutoSimplificado>()
        {
            Message = "Produto atualizado com sucesso!",
            Object = produtoDto,
            StatusCode = StatusCodes.Status204NoContent
        };
    }

    public async Task<MensagemBase<bool>> DeletarProduto(Guid id)
    {
        var produto = await _produtoRespository.BuscarPorId(id);
        if (produto == null)
        {
            return new MensagemBase<bool>()
            {
                Message = "Produto não encontrado",
                Object = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        var produtoDelete = await _produtoRespository.DeleteProduto(id);
        if (produtoDelete == false)
        {
            return new MensagemBase<bool>()
            {
                Message = "Algo deu errado! produto não removido",
                Object = false,
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        return new MensagemBase<bool>()
        {
            Object = true,
            Message = "Produto deletado com sucesso",
            StatusCode = StatusCodes.Status204NoContent
        };
    }
}
