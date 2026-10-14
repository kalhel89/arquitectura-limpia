using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Infrastructure.Persistence;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;
using Microsoft.EntityFrameworkCore;

namespace LAB08_KalhelGomez.Infrastructure.Repositories;

public class OrderdetailsRepository : IOrderdetailsRepository
{
    private readonly AppDbContext _context;

    public OrderdetailsRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Orderdetail>> GetAllAsync() =>
        await _context.Orderdetails.AsNoTracking().ToListAsync();

    public async Task<Orderdetail?> GetByIdAsync(int id) =>
        await _context.Orderdetails.FindAsync(id);

    public async Task<List<OrderProductDto>> GetProductsByOrderAsync(int orderId) =>
        await _context.Orderdetails
            .AsNoTracking()
            .Where(detail => detail.OrderId == orderId)
            .Select(detail => new OrderProductDto
            {
                ProductName = detail.Product.Name,
                Quantity = detail.Quantity
            })
            .ToListAsync();

    public async Task<int> GetTotalQuantityByOrderAsync(int orderId) =>
        await _context.Orderdetails
            .Where(detail => detail.OrderId == orderId)
            .SumAsync(detail => detail.Quantity);

    public async Task<List<OrderProductSummaryDto>> GetAllOrderProductsAsync() =>
        await _context.Orderdetails
            .AsNoTracking()
            .Select(detail => new OrderProductSummaryDto
            {
                OrderId = detail.OrderId,
                ProductName = detail.Product.Name,
                Quantity = detail.Quantity
            })
            .ToListAsync();

    public async Task<Orderdetail> CreateAsync(Orderdetail entity)
    {
        _context.Orderdetails.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Orderdetail?> UpdateAsync(int id, Orderdetail entity)
    {
        if (!await _context.Orderdetails.AnyAsync(detail => detail.OrderDetailId == id)) return null;

        _context.Orderdetails.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Orderdetails.FindAsync(id);
        if (entity is null) return false;

        _context.Orderdetails.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
