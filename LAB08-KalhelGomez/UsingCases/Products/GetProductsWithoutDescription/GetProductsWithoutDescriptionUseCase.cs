using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetProductsWithoutDescription;

public sealed class GetProductsWithoutDescriptionUseCase
{
    private readonly IProductsRepository _repository;

    public GetProductsWithoutDescriptionUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Product>> ExecuteAsync() => _repository.GetWithoutDescriptionAsync();
}
