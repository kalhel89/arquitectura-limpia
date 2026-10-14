using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.DeleteProduct;

public sealed class DeleteProductUseCase
{
    private readonly IProductsRepository _repository;

    public DeleteProductUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> ExecuteAsync(int id) => _repository.DeleteAsync(id);
}
