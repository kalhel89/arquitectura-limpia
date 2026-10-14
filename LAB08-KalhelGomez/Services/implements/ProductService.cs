using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Repositories;
using LAB08_KalhelGomez.Services;

namespace LAB08_KalhelGomez.Services.implements;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public Task<IEnumerable<Product>> GetAllAsync() =>
        _unitOfWork.Repository<Product>().GetAllAsync();

    public Task<Product?> GetByIdAsync(int id) =>
        _unitOfWork.Repository<Product>().GetByIdAsync(id);

    public async Task<List<Product>> GetMoreExpensiveThanAsync(decimal price)
    {
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();
        return products.Where(product => product.Price > price).ToList();
    }

    public async Task<Product?> GetMostExpensiveAsync()
    {
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();
        return products.OrderByDescending(product => product.Price).FirstOrDefault();
    }

    public async Task<decimal?> GetAveragePriceAsync()
    {
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();
        var prices = products.Select(product => product.Price).ToList();
        return prices.Count == 0 ? null : prices.Average();
    }

    public async Task<List<Product>> GetWithoutDescriptionAsync()
    {
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();
        return products
            .Where(product => string.IsNullOrEmpty(product.Description))
            .ToList();
    }

    public async Task<List<Product>> GetProductsSoldToClientAsync(int clientId)
    {
        var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
        var details = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();
        var clientOrderIds = orders
            .Where(order => order.ClientId == clientId)
            .Select(order => order.OrderId)
            .ToList();

        return details
            .Where(detail => clientOrderIds.Contains(detail.OrderId))
            .Join(products,
                detail => detail.ProductId,
                product => product.ProductId,
                (_, product) => product)
            .GroupBy(product => product.ProductId)
            .Select(group => group.First())
            .ToList();
    }
    public async Task<Product> CreateAsync(Product entity)
    {
        await _unitOfWork.Repository<Product>().AddAsync(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<Product?> UpdateAsync(int id, Product entity)
    {
        var repository = _unitOfWork.Repository<Product>();
        if (await repository.GetByIdAsync(id) is null) return null;
        repository.Update(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.Repository<Product>();
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return false;
        repository.Delete(entity);
        await _unitOfWork.Complete();
        return true;
    }
}



