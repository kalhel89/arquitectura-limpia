using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Infrastructure.Persistence;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;
using Microsoft.EntityFrameworkCore;

namespace LAB08_KalhelGomez.Infrastructure.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly AppDbContext _context;

    public OrdersRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await _context.Orders.AsNoTracking().ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) =>
        await _context.Orders.FindAsync(id);

    public async Task<List<Order>> GetAfterDateAsync(DateTime date) =>
        await _context.Orders
            .AsNoTracking()
            .Where(order => order.OrderDate > date)
            .ToListAsync();

    public async Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync() =>
        await _context.Orders
            .AsNoTracking()
            .GroupBy(order => new { order.ClientId, order.Client.Name })
            .Select(group => new ClientOrderCountDto
            {
                ClientId = group.Key.ClientId,
                ClientName = group.Key.Name,
                OrderCount = group.Count()
            })
            .OrderByDescending(item => item.OrderCount)
            .FirstOrDefaultAsync();

    public async Task<Order> CreateAsync(Order entity)
    {
        _context.Orders.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Order?> UpdateAsync(int id, Order entity)
    {
        if (!await _context.Orders.AnyAsync(order => order.OrderId == id)) return null;

        _context.Orders.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Orders.FindAsync(id);
        if (entity is null) return false;

        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
