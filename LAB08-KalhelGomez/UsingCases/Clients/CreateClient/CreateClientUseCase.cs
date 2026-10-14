using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.CreateClient;

public sealed class CreateClientUseCase
{
    private readonly IClientsRepository _repository;

    public CreateClientUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<Client> ExecuteAsync(Client entity) => _repository.CreateAsync(entity);
}
