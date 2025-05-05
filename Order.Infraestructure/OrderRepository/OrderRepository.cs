using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Repositories;
using Order.Infraestructure.Data;

namespace Order.Infraestructure.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        private readonly OrderDbContext _context;

        public async Task AddOrderAsync(OrderEntity order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderEntity>> GetOrdersByCustomerIdAsync(int id)
        {
            var orders = await _context.Orders.Include(o => o.OrderItems).Where(o => o.CustomerId == id).ToListAsync();

            return orders;
        }
    }
}
