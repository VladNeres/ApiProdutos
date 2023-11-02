using Aplication.SeviceInterfaces;
using ConnectionSql.Dtos;
using ConnectionSql.Dtos.ProdutosDtos;
using Domain.Messages;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMercado.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> GetAll()
    {
        var resopnse = await _produtoService.BuscarPedidos();
        if (resopnse == null) return NoContent();
        return Ok(resopnse);
    }
    [HttpGet("/Paginada")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> BuscaPaginada(int currentPge,int pageSize)
    {
        
        var resopnse = await _produtoService.BuscarPedidosPaginada( currentPge,pageSize);
        if (resopnse == null) return NoContent();
        return Ok(resopnse);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> GetFirstOrDefault(int id)
    {
        var response = await _produtoService.BuscarPedidosPorId(id);
        if (response == null) return NoContent();
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError , Type = typeof(MensagemBase<CreateCategoriaDto>))]
    public async Task<IActionResult> Post(CreateProdutoDto categoriaDto)
    {
        var response = await _produtoService.CriarProduto(categoriaDto);
        if(response == null) return NoContent();
        return CreatedAtAction(nameof(GetFirstOrDefault), new { ID = response.Object.ID }, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    public async Task<IActionResult> AtualizarProduto(int id, UpdateProdutoDto produto)
    {
        var response = await _produtoService.AtualizarPedido(id, produto);
        if (response == null) return NoContent(); 
        return Ok(response);
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<bool>))]
    public async Task<IActionResult> AtualizarParcialroduto(int id, UpdateProdutoSimplificado produtoSimplificado)
    {
        var response = await _produtoService.AtualizarPedidoSimplificado(id, produtoSimplificado);
        if (response == null || response.StatusCode == StatusCodes.Status422UnprocessableEntity) return BadRequest(response.Message);
        return Ok(response);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MensagemBase<bool>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<bool>))]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _produtoService.DeletarProduto(id);
        if (response.StatusCode == 400 || response == null)
            return BadRequest(response.Message);
        return Ok(response);
        

    }
}
