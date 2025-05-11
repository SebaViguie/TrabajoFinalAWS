using ClientApp.Dtos;
using System.Text.Json;

namespace ClientApp.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        private readonly HttpClient _client;

        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            await _client.PostAsJsonAsync("customer", customerDto);
        }
    }
}