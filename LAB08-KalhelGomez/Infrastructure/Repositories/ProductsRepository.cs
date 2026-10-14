using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Infrastructure.Persistence;
using LAB08_KalhelGomez.UsingCases.Ports;
using Microsoft.EntityFrameworkCore;

namespace LAB08_KalhelGomez.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly AppDbContext _context;

    public ProductsRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products.AsNoTracking().ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products.FindAsync(id);

    public async Task<List<Product>> GetMoreExpensiveThanAsync(decimal price) =>
        await _context.Products
            .AsNoTracking()
            .Where(product => product.Price > price)
            .ToListAsync();

    public async Task<Product?> GetMostExpensiveAsync() =>
        await _context.Products
            .AsNoTracking()
            .OrderByDescending(product => product.Price)
            .FirstOrDefaultAsync();

    public async Task<decimal?> GetAveragePriceAsync()
    {
        if (!await _context.Products.AnyAsync()) return null;

        return await _context.Products.AverageAsync(product => product.Price);
    }

    public async Task<List<Product>> GetWithoutDescriptionAsync() =>
        await _context.Products
            .AsNoTracking()
            .Where(product => product.Description == null || product.Description == "")
            .ToListAsync();

    public async Task<List<Product>> GetProductsSoldToClientAsync(int clientId) =>
        await _context.Orderdetails
            .AsNoTracking()
            .Where(detail => detail.Order.ClientId == clientId)
            .Select(detail => detail.Product)
            .Distinct()
            .ToListAsync();

    public async Task<Product> CreateAsync(Product entity)
    {
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Product?> UpdateAsync(int id, Product entity)
    {
        if (!await _context.Products.AnyAsync(product => product.ProductId == id)) return null;

        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Products.FindAsync(id);
        if (entity is null) return false;

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
