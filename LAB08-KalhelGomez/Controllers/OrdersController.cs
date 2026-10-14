using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_KalhelGomez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("after-date")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAfterDate([FromQuery] DateTime date) =>
        Ok(await _service.GetAfterDateAsync(date));
    [HttpGet("client-with-most-orders")]
    public async Task<ActionResult<ClientOrderCountDto?>> GetClientWithMostOrders() =>
        Ok(await _service.GetClientWithMostOrdersAsync());
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> Create([FromBody] Order entity)
    {
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Order>> Update(int id, [FromBody] Order entity)
    {
        if (id != entity.OrderId) return BadRequest("El id de la ruta no coincide con el id del recurso.");
        var updated = await _service.UpdateAsync(id, entity);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}




