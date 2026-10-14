using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_KalhelGomez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("more-expensive-than")]
    public async Task<ActionResult<IEnumerable<Product>>> GetMoreExpensiveThan([FromQuery] decimal price) =>
        Ok(await _service.GetMoreExpensiveThanAsync(price));

    [HttpGet("most-expensive")]
    public async Task<ActionResult<Product?>> GetMostExpensive() =>
        Ok(await _service.GetMostExpensiveAsync());

    [HttpGet("average-price")]
    public async Task<ActionResult<decimal?>> GetAveragePrice() =>
        Ok(await _service.GetAveragePriceAsync());

    [HttpGet("without-description")]
    public async Task<ActionResult<IEnumerable<Product>>> GetWithoutDescription() =>
        Ok(await _service.GetWithoutDescriptionAsync());
    [HttpGet("sold-to-client/{clientId:int}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsSoldToClient(int clientId) =>
        Ok(await _service.GetProductsSoldToClientAsync(clientId));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] Product entity)
    {
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.ProductId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> Update(int id, [FromBody] Product entity)
    {
        if (id != entity.ProductId) return BadRequest("El id de la ruta no coincide con el id del recurso.");
        var updated = await _service.UpdateAsync(id, entity);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}


