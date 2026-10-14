using LAB08_KalhelGomez.Models;

namespace LAB08_KalhelGomez.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<List<Product>> GetMoreExpensiveThanAsync(decimal price);
    Task<Product?> GetMostExpensiveAsync();
    Task<decimal?> GetAveragePriceAsync();
    Task<List<Product>> GetWithoutDescriptionAsync();
    Task<List<Product>> GetProductsSoldToClientAsync(int clientId);
    Task<Product> CreateAsync(Product entity);
    Task<Product?> UpdateAsync(int id, Product entity);
    Task<bool> DeleteAsync(int id);
}
