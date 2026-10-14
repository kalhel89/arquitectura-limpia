using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetProductsMoreExpensiveThan;

public sealed class GetProductsMoreExpensiveThanUseCase
{
    private readonly IProductsRepository _repository;

    public GetProductsMoreExpensiveThanUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Product>> ExecuteAsync(decimal price) => _repository.GetMoreExpensiveThanAsync(price);
}
