using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.CreateOrderdetail;

public sealed class CreateOrderdetailUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public CreateOrderdetailUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<Orderdetail> ExecuteAsync(Orderdetail entity) => _repository.CreateAsync(entity);
}
