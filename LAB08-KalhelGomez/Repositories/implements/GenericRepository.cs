using LAB08_KalhelGomez.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_KalhelGomez.Repositories.implements;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

    public void Update(TEntity entity) => _dbSet.Update(entity);

    public void Delete(TEntity entity) => _dbSet.Remove(entity);
}