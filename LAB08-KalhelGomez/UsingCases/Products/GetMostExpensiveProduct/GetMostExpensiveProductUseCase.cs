using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetMostExpensiveProduct;

public sealed class GetMostExpensiveProductUseCase
{
    private readonly IProductsRepository _repository;

    public GetMostExpensiveProductUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<Product?> ExecuteAsync() => _repository.GetMostExpensiveAsync();
}
