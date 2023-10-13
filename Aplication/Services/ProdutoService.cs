using Aplication.Mappers.mapperProduto;
using Aplication.SeviceInterfaces;
using ConnectionSql.Dtos.ProdutosDtos;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;
using Domain.Messages;
using Domain.Models;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace Aplication.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRespository;
    private readonly IDataTableToBulk _dataTableToBulk;
    public ProdutoService(IProdutoRepository produtoRespository, IDataTableToBulk dataTableToBulk)
    {
        _produtoRespository = produtoRespository;
        this._dataTableToBulk = dataTableToBulk;
    }


    public async Task<MensagemBase<Paginacao<List<ReadProdutoDto>>>> BuscarPedidosPaginada(int currentPge, int pageSize)
    {

        var produtos = await _produtoRespository.BuscarPedidoPaginada(currentPge, pageSize);
        
        var response = MapperProduto.ParaPaginacao(produtos);
        if (response == null)
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
        if (response == null)
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

    public async Task<MensagemBase<ReadProdutoDto>> BuscarPedidosPorId(int id)
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
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        var produto = MapperProduto.CreateParaProduto(produtoDto);
        DataTable dataTable = _dataTableToBulk.MakeTable(produto.PraraProdutoType());
        await _produtoRespository.CriarProduto(produto);
        return new MensagemBase<Produto>()
        {
            Message = "Produto criado com sucesso!",
            Object = produto,
            StatusCode = StatusCodes.Status201Created
        };
    }


    public async Task<MensagemBase<UpdateProdutoDto>> AtualizarPedido(int id, UpdateProdutoDto produtoDto)
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

        if (existeNaBase.FirstOrDefault(p => p.ID == id) == null)
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


    public async Task<MensagemBase<UpdateProdutoSimplificado>> AtualizarPedidoSimplificado(int id, UpdateProdutoSimplificado produtoDto)
    {
        var existeNaBase = await _produtoRespository.BuscarPedidoCompleto();
        if (existeNaBase.FirstOrDefault(p => p.Nome == produtoDto.Nome) != null)
        {
            return new MensagemBase<UpdateProdutoSimplificado>()
            {
                Message = "O produto ja existe",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        if (existeNaBase.FirstOrDefault(p => p.ID == id) == null)
        {
            return new MensagemBase<UpdateProdutoSimplificado>()
            {
                Message = "O produto não foi encontrado",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        var produto = MapperProduto.UpdateSimplificadoParaProduto(produtoDto);
        await _produtoRespository.AtualizarProdutoSimplificado(id, produto);
        return new MensagemBase<UpdateProdutoSimplificado>()
        {
            Message = "Produto atualizado com sucesso!",
            Object = produtoDto,
            StatusCode = StatusCodes.Status204NoContent
        };
    }

    public async Task<MensagemBase<bool>> DeletarProduto(int id)
    {
        var produto = _produtoRespository.BuscarPorId(id);
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
        if (produtoDelete)
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
