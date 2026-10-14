using LAB08_KalhelGomez.Domain.Entities;
using LAB08_KalhelGomez.UsingCases.Ports;

namespace LAB08_KalhelGomez.UsingCases.Products.GetAverageProductPrice;

public sealed class GetAverageProductPriceUseCase
{
    private readonly IProductsRepository _repository;

    public GetAverageProductPriceUseCase(IProductsRepository repository)
    {
        _repository = repository;
    }

    public Task<decimal?> ExecuteAsync() => _repository.GetAveragePriceAsync();
}
