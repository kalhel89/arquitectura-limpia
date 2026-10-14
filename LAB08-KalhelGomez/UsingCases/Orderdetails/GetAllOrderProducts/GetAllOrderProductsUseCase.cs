using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.GetAllOrderProducts;

public sealed class GetAllOrderProductsUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public GetAllOrderProductsUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<List<OrderProductSummaryDto>> ExecuteAsync() => _repository.GetAllOrderProductsAsync();
}
