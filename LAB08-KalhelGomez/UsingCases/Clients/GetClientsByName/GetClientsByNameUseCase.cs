using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.GetClientsByName;

public sealed class GetClientsByNameUseCase
{
    private readonly IClientsRepository _repository;

    public GetClientsByNameUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Client>> ExecuteAsync(string name) => _repository.GetByNameAsync(name);
}
