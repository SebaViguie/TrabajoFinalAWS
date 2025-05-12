using ClientApp.Dtos;

namespace ClientApp.Services.Order
{
    public class OrderService : IOrderService
    {
        public OrderService(HttpClient client)
        {
            _client = client;
        }

        private readonly HttpClient _client;

        public async Task<List<CustomerOrderDto>> GetOrdersAsync(int customerId)
        {
            var response = await _client.GetFromJsonAsync<List<CustomerOrderDto>>($"order/{customerId}");

            return response;
        }

        public async Task AddOrderAsync(OrderDto orderDto)
        {
            await _client.PostAsJsonAsync("order", orderDto);
        }
    }
}
