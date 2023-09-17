using Aplication.Mappers.mapperProduto;
using Aplication.SeviceInterfaces;
using ConnectionSql.Dtos.ProdutosDtos;
using ConnectionSql.RepositopriesInterfaces;
using ConnectionSql.Repositories;
using Domain.Messages;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Http;

namespace Aplication.Services;

public class ProdutoService: IProdutoService
{
    private readonly IProdutoRepository _produtoRespository;

    public ProdutoService(IProdutoRepository produtoRespository)
    {
        _produtoRespository = produtoRespository;
    }


    public async Task<MensagemBase<List<Produto>>> BuscarPedidos()
    {
       var response = await _produtoRespository.BuscarPedidoCompleto();
        if (response == null)
            return new MensagemBase<List<Produto>>()
            {
                Message = "Lista vazia",
                StatusCode = StatusCodes.Status204NoContent
            };
        return new MensagemBase<List<Produto>>()
        {
            Object = response,
            StatusCode = StatusCodes.Status200OK
        };
    }

    public async Task<MensagemBase<Produto>> BuscarPedidosPorId(int id)
    {
        var response =  await _produtoRespository.BuscarPorId(id);
        if (response == null)
            return new MensagemBase<Produto>()
            {
                Message = "Pedido não encontrado",
                StatusCode = StatusCodes.Status204NoContent
            };
        return new MensagemBase<Produto>()
        {
            Object = response,
            StatusCode = StatusCodes.Status200OK
        };
    }

    public async Task<MensagemBase<Produto>> CriarProduto(CreateProdutoDto produtoDto)
    {
        var existeNaBase = await _produtoRespository.BuscarPedidoCompleto();
        if(existeNaBase.FirstOrDefault(p => p.Nome  == produtoDto.Nome) != null)
        {
            return new MensagemBase<Produto>()
            {
                Message = "O produto ja existe",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

       var produto = MapperProduto.CreateParaProduto(produtoDto);
         await _produtoRespository.CriarProduto(produto);
        return new MensagemBase<Produto>()
        {
            Message = "Produto criado com sucesso!",
            Object = produto,
            StatusCode = StatusCodes.Status201Created
        };
    }


    public async Task<MensagemBase<Produto>> CriarProduto(UpdateProdutoDto produtoDto)
    {
        var existeNaBase = await _produtoRespository.BuscarPedidoCompleto();
        if (existeNaBase.FirstOrDefault(p => p.Nome == produtoDto.Nome) != null)
        {
            return new MensagemBase<Produto>()
            {
                Message = "O produto ja existe",
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        var produto = MapperProduto.UpdateParaProduto(produtoDto);
        await _produtoRespository.CriarProduto(produto);
        return new MensagemBase<Produto>()
        {
            Message = "Produto criado com sucesso!",
            Object = produto,
            StatusCode = StatusCodes.Status201Created
        };
    }
}
