using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Clients.DeleteClient;

public sealed class DeleteClientUseCase
{
    private readonly IClientsRepository _repository;

    public DeleteClientUseCase(IClientsRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> ExecuteAsync(int id) => _repository.DeleteAsync(id);
}
