using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Repositories;
using LAB08_KalhelGomez.Services;

namespace LAB08_KalhelGomez.Services.implements;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public Task<IEnumerable<Client>> GetAllAsync() =>
        _unitOfWork.Repository<Client>().GetAllAsync();

    public Task<Client?> GetByIdAsync(int id) =>
        _unitOfWork.Repository<Client>().GetByIdAsync(id);

    public async Task<List<Client>> GetByNameAsync(string name)
    {
        var clients = await _unitOfWork.Repository<Client>().GetAllAsync();
        return clients
            .Where(client => client.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task<List<Client>> GetClientsWhoBoughtProductAsync(int productId)
    {
        var details = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();
        var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
        var clients = await _unitOfWork.Repository<Client>().GetAllAsync();

        return details
            .Where(detail => detail.ProductId == productId)
            .Join(orders,
                detail => detail.OrderId,
                order => order.OrderId,
                (detail, order) => order.ClientId)
            .Join(clients,
                clientId => clientId,
                client => client.ClientId,
                (_, client) => client)
            .GroupBy(client => client.ClientId)
            .Select(group => group.First())
            .ToList();
    }
    public async Task<Client> CreateAsync(Client entity)
    {
        await _unitOfWork.Repository<Client>().AddAsync(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<Client?> UpdateAsync(int id, Client entity)
    {
        var repository = _unitOfWork.Repository<Client>();
        if (await repository.GetByIdAsync(id) is null) return null;
        repository.Update(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.Repository<Client>();
        var entity = await repository.GetByIdAsync(id);
        if (entity is null) return false;
        repository.Delete(entity);
        await _unitOfWork.Complete();
        return true;
    }
}





