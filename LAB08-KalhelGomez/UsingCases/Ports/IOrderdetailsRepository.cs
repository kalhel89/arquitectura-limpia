using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;

namespace LAB08_KalhelGomez.UsingCases.Ports;

public interface IOrderdetailsRepository
{
    Task<IEnumerable<Orderdetail>> GetAllAsync();
    Task<Orderdetail?> GetByIdAsync(int id);
    Task<List<OrderProductDto>> GetProductsByOrderAsync(int orderId);
    Task<int> GetTotalQuantityByOrderAsync(int orderId);
    Task<List<OrderProductSummaryDto>> GetAllOrderProductsAsync();
    Task<Orderdetail> CreateAsync(Orderdetail entity);
    Task<Orderdetail?> UpdateAsync(int id, Orderdetail entity);
    Task<bool> DeleteAsync(int id);
}
