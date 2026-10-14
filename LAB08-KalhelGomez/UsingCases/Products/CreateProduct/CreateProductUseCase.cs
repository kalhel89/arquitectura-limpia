using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.CreateProduct;

public sealed class CreateProductUseCase
{
    private readonly IProductsRepository _repository;

    public CreateProductUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<Product> ExecuteAsync(Product entity) => _repository.CreateAsync(entity);
}
