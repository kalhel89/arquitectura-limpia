using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetAllProducts;

public sealed class GetAllProductsUseCase
{
    private readonly IProductsRepository _repository;

    public GetAllProductsUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Product>> ExecuteAsync() => _repository.GetAllAsync();
}
