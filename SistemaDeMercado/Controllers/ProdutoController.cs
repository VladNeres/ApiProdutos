using Aplication.SeviceInterfaces;
using ConnectionSql.Dtos;
using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Messages;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMercado.Controllers;

[Route("[controller]")]
public class ProdutoController : Controller
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> GetAll()
    {
        var resopnse = await _produtoService.BuscarPedidos();
        if (resopnse == null) return NoContent();
        return Ok(resopnse);
    }
    [HttpGet]
    [Route("BuscaPaginada")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> BuscaPaginada(int currentPge,int pageSize)
    {
        var resopnse = await _produtoService.BuscarPedidosPaginada( currentPge,pageSize);
        if (resopnse == null) return NoContent();
        return Ok(resopnse);
    }

    [HttpGet]
    [Route("BuscarProduto/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> GetFirstOrDefault(Guid id)
    {
        var response = await _produtoService.BuscarProdutosPorId(id);
        if (response == null) return NoContent();
        return Ok(response);
    }

    [HttpPost]
    [Route("CriarProduto")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError , Type = typeof(MensagemBase<CreateCategoriaDto>))]
    public async Task<IActionResult> Post([FromBody] CreateProdutoDto categoriaDto)
    {
        var response = await _produtoService.CriarProduto(categoriaDto);
        if(response == null) return NoContent();
        return CreatedAtAction(nameof(GetFirstOrDefault), new { ID = response.Object.CodigoProduto }, response);
    }

    [HttpPut]
    [Route("AtualizarProduto/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    public async Task<IActionResult> AtualizarProduto(Guid id,[FromBody] UpdateProdutoDto produto)
    {
        var response = await _produtoService.AtualizarPedido(id, produto);
        if (response == null) return NoContent(); 
        return Ok(response);
    }

    [HttpPatch]
    [Route("Atualizar")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<bool>))]
    public async Task<IActionResult> AtualizarProdutoParcial([FromBody] UpdateProdutoSimplificado produtoSimplificado)
    {
        var response = await _produtoService.AtualizarPedidoSimplificado(produtoSimplificado);
        if (response == null || response.StatusCode != StatusCodes.Status200OK) return BadRequest(response.Message);
        return Ok(response);
    }


    [HttpDelete]
    [Route("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<bool>))]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _produtoService.DeletarProduto(id);
        if (response.StatusCode == 400 || response == null)
            return BadRequest(response.Message);
        return Ok(response);
        

    }
}
