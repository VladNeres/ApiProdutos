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
        return Ok();
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
    public async Task<IActionResult> GetFirst(int id)
    {
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType (typeof (int), 201)]
    [ProducesResponseType (typeof (int), 500)]
    public async Task<IActionResult> CriarCategoria([FromBody] Categoria categoria)
    {
        var response = _categoriaService.CriarCategoria(categoria);
        if(response == null) return BadRequest();
        return Ok(response); 
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
