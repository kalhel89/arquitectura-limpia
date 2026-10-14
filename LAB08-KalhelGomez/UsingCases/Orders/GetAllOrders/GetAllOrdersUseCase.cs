using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.GetAllOrders;

public sealed class GetAllOrdersUseCase
{
    private readonly IOrdersRepository _repository;

    public GetAllOrdersUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Order>> ExecuteAsync() => _repository.GetAllAsync();
}
