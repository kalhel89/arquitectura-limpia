using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.UpdateOrderdetail;

public sealed class UpdateOrderdetailUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public UpdateOrderdetailUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<Orderdetail?> ExecuteAsync(int id, Orderdetail entity) => _repository.UpdateAsync(id, entity);
}
