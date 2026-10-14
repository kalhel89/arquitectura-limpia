using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.GetClientById;

public sealed class GetClientByIdUseCase
{
    private readonly IClientsRepository _repository;

    public GetClientByIdUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<Client?> ExecuteAsync(int id) => _repository.GetByIdAsync(id);
}
