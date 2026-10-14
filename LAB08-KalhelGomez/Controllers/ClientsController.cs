using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_KalhelGomez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _service;

    public ClientsController(IClientService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Client>>> GetByName([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Debe especificar el nombre que desea buscar.");

        return Ok(await _service.GetByNameAsync(name.Trim()));
    }

    [HttpGet("who-bought-product/{productId:int}")]
    public async Task<ActionResult<IEnumerable<Client>>> GetClientsWhoBoughtProduct(int productId) =>
        Ok(await _service.GetClientsWhoBoughtProductAsync(productId));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Client>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Create([FromBody] Client entity)
    {
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.ClientId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Client>> Update(int id, [FromBody] Client entity)
    {
        if (id != entity.ClientId) return BadRequest("El id de la ruta no coincide con el id del recurso.");
        var updated = await _service.UpdateAsync(id, entity);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}


