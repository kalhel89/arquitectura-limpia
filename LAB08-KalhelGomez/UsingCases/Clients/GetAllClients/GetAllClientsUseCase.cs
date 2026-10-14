using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.GetAllClients;

public sealed class GetAllClientsUseCase
{
    private readonly IClientsRepository _repository;

    public GetAllClientsUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Client>> ExecuteAsync() => _repository.GetAllAsync();
}
