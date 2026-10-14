using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.UpdateOrder;

public sealed class UpdateOrderUseCase
{
    private readonly IOrdersRepository _repository;

    public UpdateOrderUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<Order?> ExecuteAsync(int id, Order entity) => _repository.UpdateAsync(id, entity);
}
