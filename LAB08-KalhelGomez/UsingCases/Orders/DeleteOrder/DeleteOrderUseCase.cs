using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.DeleteOrder;

public sealed class DeleteOrderUseCase
{
    private readonly IOrdersRepository _repository;

    public DeleteOrderUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> ExecuteAsync(int id) => _repository.DeleteAsync(id);
}
