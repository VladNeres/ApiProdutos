using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMercado.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
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

}
