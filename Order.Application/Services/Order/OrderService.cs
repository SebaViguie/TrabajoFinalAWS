using Order.Application.Dtos;
using Order.Application.Services.Customer;
using Order.Application.Services.Product;
using Order.Domain.Entities;
using Order.Domain.Repositories;

namespace Order.Application.Services.Order
{
    public class OrderService : IOrderService
    {
        public OrderService(IOrderRepository repository, IProductService product, ICustomerService customer)
        {
            _repository = repository;
            _product = product;
            _customer = customer;
        }

        private readonly IOrderRepository _repository;
        private readonly IProductService _product;
        private readonly ICustomerService _customer;
        public async Task AddOrderAsync(CreateOrderDto order)
        {
            var customer = await _customer.GetCustomerInfoAsync(order.CustomerId);
            var products = new List<OrderItemEntity>();
            decimal total = 0;

            foreach (var item in order.OrderItems)
            {
                var product = await _product.GetProductInfoAsync(item.ProductId);
                var productStock = 0;

                if (item.Quantity > product.Stock)
                {
                    productStock = product.Stock;
                }
                else
                {
                    productStock = item.Quantity;
                }

                var orderItem = new OrderItemEntity
                {
                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Quantity = productStock,
                    TotalPrice = product.Price * productStock
                };

                var updatedItem = new UpdateProductDto
                {
                    Id = item.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock - productStock
                };

                products.Add(orderItem);
                total += orderItem.TotalPrice;

                await _product.UpdateProductAsync(updatedItem);
            }

            var orderEntity = new OrderEntity
            {
                CustomerId = order.CustomerId,
                CustomerName = customer.Name,
                TotalAmount = total,
                OrderItems = products
            };

            await _repository.AddOrderAsync(orderEntity);
        }

        public async Task<List<OrderEntity>> GetOrdersByCustomerIdAsync(int id)
        {
            var orders = await _repository.GetOrdersByCustomerIdAsync(id);

            return orders;
        }
    }
}
