using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.GetOrderdetailById;

public sealed class GetOrderdetailByIdUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public GetOrderdetailByIdUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<Orderdetail?> ExecuteAsync(int id) => _repository.GetByIdAsync(id);
}
