using Aplication.interfaces;
using ConnectionSql.Dtos;
using Domain.ViewlModels;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMercado.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
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
    [ProducesResponseType(typeof(int), 200)]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 500)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _categoriaService.BuscarTodasCategorias();
        if(response == null) return NoContent();
        return Ok(response);
    }

    /// <summary>
    /// End point é responsavel por retornar apenas uma categoria
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet ("{id}")]
    [ProducesResponseType(typeof (int), 200)]
    [ProducesResponseType(typeof (int), 204)]
    [ProducesResponseType(typeof (int), 400)]
    public async Task<IActionResult> GetFirstOrDefault(int id)
    {
        var response = await _categoriaService.BuscarCategoriasPorId(id);
        if(response == null) return NoContent(); return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType (typeof (int), 201)]
    [ProducesResponseType (typeof (int), 500)]
    public async Task<IActionResult> CriarCategoria([FromBody] CreateCategoriaDto categoria)
    {
        try
        {
            var response = _categoriaService.CriarCategoria(categoria);
            if(response.IsFaulted) return BadRequest(response.Result);
            return Ok(response); 

        }
        catch (Exception ex)
        {

            return StatusCode(500,ex.Message);
        }
    }

    [HttpPatch]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 500)]
    public async Task<IActionResult> AtualizarParcialmente(int id, [FromBody] UpdateCategoriaDto categoria)
    {
       return Ok(categoria);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 500)]
    public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateCategoriaDto categoria)
    {
        return Ok(categoria);
    }

}
