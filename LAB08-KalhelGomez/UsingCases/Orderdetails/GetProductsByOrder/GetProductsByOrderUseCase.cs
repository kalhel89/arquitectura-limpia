using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.GetProductsByOrder;

public sealed class GetProductsByOrderUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public GetProductsByOrderUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<OrderProductDto>> ExecuteAsync(int orderId) => _repository.GetProductsByOrderAsync(orderId);
}
