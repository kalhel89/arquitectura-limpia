using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Infrastructure.Persistence;
using LAB08_KalhelGomez.UsingCases.Ports;
using Microsoft.EntityFrameworkCore;

namespace LAB08_KalhelGomez.Infrastructure.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly AppDbContext _context;

    public ClientsRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Client>> GetAllAsync() =>
        await _context.Clients.AsNoTracking().ToListAsync();

    public async Task<Client?> GetByIdAsync(int id) =>
        await _context.Clients.FindAsync(id);

    public async Task<List<Client>> GetByNameAsync(string name) =>
        await _context.Clients
            .AsNoTracking()
            .Where(client => client.Name.StartsWith(name))
            .ToListAsync();

    public async Task<List<Client>> GetClientsWhoBoughtProductAsync(int productId) =>
        await _context.Orderdetails
            .AsNoTracking()
            .Where(detail => detail.ProductId == productId)
            .Select(detail => detail.Order.Client)
            .Distinct()
            .ToListAsync();

    public async Task<Client> CreateAsync(Client entity)
    {
        _context.Clients.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Client?> UpdateAsync(int id, Client entity)
    {
        if (!await _context.Clients.AnyAsync(client => client.ClientId == id)) return null;

        _context.Clients.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Clients.FindAsync(id);
        if (entity is null) return false;

        _context.Clients.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
