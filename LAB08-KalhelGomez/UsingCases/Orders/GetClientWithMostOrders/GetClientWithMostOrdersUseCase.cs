using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orders.GetClientWithMostOrders;

public sealed class GetClientWithMostOrdersUseCase
{
    private readonly IOrdersRepository _repository;

    public GetClientWithMostOrdersUseCase(IOrdersRepository repository)
    {
        _repository = repository;
    }

    public Task<ClientOrderCountDto?> ExecuteAsync() => _repository.GetClientWithMostOrdersAsync();
}
