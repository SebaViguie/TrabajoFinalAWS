using Order.Application.Dtos;
using Order.Domain.Entities;

namespace Order.Application.Services.Order
{
    public interface IOrderService
    {
        Task AddOrderAsync(CreateOrderDto order);
        Task<List<OrderEntity>> GetOrdersByCustomerIdAsync(int id);
    }
}
