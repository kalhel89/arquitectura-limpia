using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.UpdateProduct;

public sealed class UpdateProductUseCase
{
    private readonly IProductsRepository _repository;

    public UpdateProductUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<Product?> ExecuteAsync(int id, Product entity) => _repository.UpdateAsync(id, entity);
}
