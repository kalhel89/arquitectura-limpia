using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.GetAllOrderdetails;

public sealed class GetAllOrderdetailsUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public GetAllOrderdetailsUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Orderdetail>> ExecuteAsync() => _repository.GetAllAsync();
}
