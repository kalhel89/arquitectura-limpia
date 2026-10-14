using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.Repositories;
using LAB08_KalhelGomez.Services;

namespace LAB08_KalhelGomez.Services.implements;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public Task<IEnumerable<Order>> GetAllAsync() =>
        _unitOfWork.Repository<Order>().GetAllAsync();

    public Task<Order?> GetByIdAsync(int id) =>
        _unitOfWork.Repository<Order>().GetByIdAsync(id);
    public async Task<List<Order>> GetAfterDateAsync(DateTime date)
    {
        var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
        return orders.Where(order => order.OrderDate > date).ToList();
    }

    public async Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync()
    {
        var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
        var clients = await _unitOfWork.Repository<Client>().GetAllAsync();

        var topClient = orders
            .GroupBy(order => order.ClientId)
            .Select(group => new
            {
                ClientId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(group => group.OrderCount)
            .FirstOrDefault();

        if (topClient is null) return null;

        var client = clients.FirstOrDefault(item => item.ClientId == topClient.ClientId);
        if (client is null) return null;

        return new ClientOrderCountDto
        {
            ClientId = client.ClientId,
            ClientName = client.Name,
            OrderCount = topClient.OrderCount
        };
    }
    public async Task<Order> CreateAsync(Order entity)
    {
        await _unitOfWork.Repository<Order>().AddAsync(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<Order?> UpdateAsync(int id, Order entity)
    {
        var repository = _unitOfWork.Repository<Order>();
        if (await repository.GetByIdAsync(id) is null) return null;
        repository.Update(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.Repository<Order>();
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return false;
        repository.Delete(entity);
        await _unitOfWork.Complete();
        return true;
    }
}





