using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.CreateOrder;

public sealed class CreateOrderUseCase
{
    private readonly IOrdersRepository _repository;

    public CreateOrderUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<Order> ExecuteAsync(Order entity) => _repository.CreateAsync(entity);
}
