using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetProductsSoldToClient;

public sealed class GetProductsSoldToClientUseCase
{
    private readonly IProductsRepository _repository;

    public GetProductsSoldToClientUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Product>> ExecuteAsync(int clientId) => _repository.GetProductsSoldToClientAsync(clientId);
}
