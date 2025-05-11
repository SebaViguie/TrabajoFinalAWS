using ClientApp.Dtos;

namespace ClientApp.Services.Order
{
    public interface IOrderService
    {
        Task<List<CustomerOrderDto>> GetOrdersAsync(int customerId);
    }
}
