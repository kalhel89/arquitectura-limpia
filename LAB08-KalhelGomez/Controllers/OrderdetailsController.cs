using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.Services;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_KalhelGomez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderdetailsController : ControllerBase
{
    private readonly IOrderdetailService _service;

    public OrderdetailsController(IOrderdetailService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Orderdetail>>> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("by-order/{orderId:int}/products")]
    public async Task<ActionResult<IEnumerable<OrderProductDto>>> GetProductsByOrder(int orderId) =>
        Ok(await _service.GetProductsByOrderAsync(orderId));

    [HttpGet("by-order/{orderId:int}/total-quantity")]
    public async Task<ActionResult<int>> GetTotalQuantityByOrder(int orderId) =>
        Ok(await _service.GetTotalQuantityByOrderAsync(orderId));
    [HttpGet("all-orders-with-products")]
    public async Task<ActionResult<IEnumerable<OrderProductSummaryDto>>> GetAllOrderProducts() =>
        Ok(await _service.GetAllOrderProductsAsync());
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Orderdetail>> GetById(int id)
    {
        var entity = await _service.GetByIdAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult<Orderdetail>> Create([FromBody] Orderdetail entity)
    {
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.OrderDetailId }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Orderdetail>> Update(int id, [FromBody] Orderdetail entity)
    {
        if (id != entity.OrderDetailId) return BadRequest("El id de la ruta no coincide con el id del recurso.");
        var updated = await _service.UpdateAsync(id, entity);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _service.DeleteAsync(id) ? NoContent() : NotFound();
}





