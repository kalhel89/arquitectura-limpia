using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.UpdateClient;

public sealed class UpdateClientUseCase
{
    private readonly IClientsRepository _repository;

    public UpdateClientUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<Client?> ExecuteAsync(int id, Client entity) => _repository.UpdateAsync(id, entity);
}
