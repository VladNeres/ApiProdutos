using Aplication.interfaces;
using ConnectionSql.Dtos;
using Domain.Messages;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMercado.Controllers;


[Route("[controller]")]
public class CategoriaController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    /// <summary>
    /// End Point responsavel por retornar todas as categorias cadastradas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarCategorias")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> GetAll()
    {
        MensagemBase<IEnumerable<ReadCategoriaDto>> response = await _categoriaService.BuscarTodasCategorias();
        if (response == null) return NoContent();
        return Ok(response);
    }

    /// <summary>
    /// End point é responsavel por retornar apenas uma categoria
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("BuscarCategoria/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status204NoContent,Type = typeof(MensagemBase<ReadCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type =typeof(MensagemBase<ReadCategoriaDto>))]
    public async Task<IActionResult> GetFirstOrDefault(int id)
    {
        var response = await _categoriaService.BuscarCategoriasPorId(id);
        return Ok(response);
    }

    [HttpPost]
    [Route("CriarCategoria")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<CreateCategoriaDto>))]
    public async Task<IActionResult> CriarCategoria([FromBody] CreateCategoriaDto categoria)
    {
        try
        {
            var response = await  _categoriaService.CriarCategoria(categoria);
            if (response.StatusCode != StatusCodes.Status201Created) return BadRequest(response);
            return  Ok(response);

        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<UpdateCategoriaDto>))]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateCategoriaDto categoria)
    {
        try
        {
            MensagemBase<UpdateCategoriaDto> response = await _categoriaService.AtualizarCategoria(id, categoria);

            if (response.StatusCode >= 400) return BadRequest();
            return NoContent();

        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }


    [HttpDelete]
    [Route("Deletar/{id}")]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(MensagemBase<Categoria>))]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MensagemBase<Categoria>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MensagemBase<Categoria>))]
    public async Task<IActionResult> DeletarCategoria(int id)
    {
      var response = await _categoriaService.DeletarCategoria(id);
        if (response.StatusCode == StatusCodes.Status422UnprocessableEntity) return BadRequest(response.Message);
        return NoContent();
    }
}
