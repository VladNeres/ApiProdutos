using Microsoft.AspNetCore.Mvc;

namespace SistemaDeMercado.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(int), 200)]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 500)]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(int), 200)]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 500)]
    public IActionResult GetFirstOrDefalt()
    {
        return Ok();
    }


    [HttpPut]
    [ProducesResponseType(typeof (int), 204)]
    [ProducesResponseType(typeof (int), 400)]
    [ProducesResponseType(typeof (int), 500)]
    public IActionResult AtualizarProduto()
    {
        return Ok();
    }

    [HttpPatch]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 400)]
    [ProducesResponseType(typeof(int), 500)]
    public IActionResult AtualizarPParcialroduto()
    {
        return Ok();
    }


    [HttpDelete]
    [ProducesResponseType(typeof(int), 204)]
    [ProducesResponseType(typeof(int), 400)]
    [ProducesResponseType(typeof(int), 500)]
    public IActionResult Delete()
    {
        return Ok();
    }
}
