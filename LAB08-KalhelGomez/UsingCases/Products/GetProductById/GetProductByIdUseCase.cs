using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetProductById;

public sealed class GetProductByIdUseCase
{
    private readonly IProductsRepository _repository;

    public GetProductByIdUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<Product?> ExecuteAsync(int id) => _repository.GetByIdAsync(id);
}
