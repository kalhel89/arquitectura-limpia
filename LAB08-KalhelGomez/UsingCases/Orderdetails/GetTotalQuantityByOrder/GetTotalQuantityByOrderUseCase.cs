using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.GetTotalQuantityByOrder;

public sealed class GetTotalQuantityByOrderUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public GetTotalQuantityByOrderUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<int> ExecuteAsync(int orderId) => _repository.GetTotalQuantityByOrderAsync(orderId);
}
