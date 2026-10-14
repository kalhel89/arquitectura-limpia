using LAB08_KalhelGomez.Models;
using LAB08_KalhelGomez.Models.Dtos;
using LAB08_KalhelGomez.Repositories;

namespace LAB08_KalhelGomez.Services.implements;

public class OrderdetailService : IOrderdetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderdetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<Orderdetail>> GetAllAsync()
    {
        return _unitOfWork.Repository<Orderdetail>().GetAllAsync();
    }

    public Task<Orderdetail?> GetByIdAsync(int id)
    {
        return _unitOfWork.Repository<Orderdetail>().GetByIdAsync(id);
    }

    public async Task<List<OrderProductDto>> GetProductsByOrderAsync(int orderId)
    {
        var details = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();

        return details
            .Where(detail => detail.OrderId == orderId)
            .Join(products,
                detail => detail.ProductId,
                product => product.ProductId,
                (detail, product) => new OrderProductDto
                {
                    ProductName = product.Name,
                    Quantity = detail.Quantity
                })
            .ToList();
    }

    public async Task<int> GetTotalQuantityByOrderAsync(int orderId)
    {
        var details = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();

        return details
            .Where(detail => detail.OrderId == orderId)
            .Select(detail => detail.Quantity)
            .Sum();
    }

    public async Task<List<OrderProductSummaryDto>> GetAllOrderProductsAsync()
    {
        var orders = await _unitOfWork.Repository<Order>().GetAllAsync();
        var details = await _unitOfWork.Repository<Orderdetail>().GetAllAsync();
        var products = await _unitOfWork.Repository<Product>().GetAllAsync();
        var orderIds = orders.Select(order => order.OrderId).ToList();

        return details
            .Where(detail => orderIds.Contains(detail.OrderId))
            .Join(products,
                detail => detail.ProductId,
                product => product.ProductId,
                (detail, product) => new OrderProductSummaryDto
                {
                    OrderId = detail.OrderId,
                    ProductName = product.Name,
                    Quantity = detail.Quantity
                })
            .ToList();
    }

    public async Task<Orderdetail> CreateAsync(Orderdetail entity)
    {
        await _unitOfWork.Repository<Orderdetail>().AddAsync(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<Orderdetail?> UpdateAsync(int id, Orderdetail entity)
    {
        var repository = _unitOfWork.Repository<Orderdetail>();
        var detail = await repository.GetByIdAsync(id);

        if (detail is null)
        {
            return null;
        }

        repository.Update(entity);
        await _unitOfWork.Complete();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var repository = _unitOfWork.Repository<Orderdetail>();
        var detail = await repository.GetByIdAsync(id);

        if (detail is null)
        {
            return false;
        }

        repository.Delete(detail);
        await _unitOfWork.Complete();
        return true;
    }
}
