using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.GetOrdersAfterDate;

public sealed class GetOrdersAfterDateUseCase
{
    private readonly IOrdersRepository _repository;

    public GetOrdersAfterDateUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Order>> ExecuteAsync(DateTime date) => _repository.GetAfterDateAsync(date);
}
