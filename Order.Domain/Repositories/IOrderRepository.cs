using Order.Domain.Entities;

namespace Order.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(OrderEntity order);
        Task<List<OrderEntity>> GetOrdersByCustomerIdAsync(int id);
    }
}
