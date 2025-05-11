using ClientApp.Dtos;
using System.Text.Json;

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
    }
}
