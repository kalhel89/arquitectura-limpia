using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;

namespace LAB08_KalhelGomez.UsingCases.Ports;

public interface IOrdersRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<List<Order>> GetAfterDateAsync(DateTime date);
    Task<ClientOrderCountDto?> GetClientWithMostOrdersAsync();
    Task<Order> CreateAsync(Order entity);
    Task<Order?> UpdateAsync(int id, Order entity);
    Task<bool> DeleteAsync(int id);
}
