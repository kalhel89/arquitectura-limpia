using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.GetOrderById;

public sealed class GetOrderByIdUseCase
{
    private readonly IOrdersRepository _repository;

    public GetOrderByIdUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<Order?> ExecuteAsync(int id) => _repository.GetByIdAsync(id);
}
