using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.GetClientsWhoBoughtProduct;

public sealed class GetClientsWhoBoughtProductUseCase
{
    private readonly IClientsRepository _repository;

    public GetClientsWhoBoughtProductUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Client>> ExecuteAsync(int productId) => _repository.GetClientsWhoBoughtProductAsync(productId);
}
