using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Orderdetails.DeleteOrderdetail;

public sealed class DeleteOrderdetailUseCase
{
    private readonly IOrderdetailsRepository _repository;

    public DeleteOrderdetailUseCase(IOrderdetailsRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> ExecuteAsync(int id) => _repository.DeleteAsync(id);
}
