using Order.Application.Dtos;
using System.Net.Http.Json;

namespace Order.Application.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        public async Task<CustomerInfoDto> GetCustomerInfoAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7214/");
            var result = await client.GetFromJsonAsync<CustomerInfoDto>($"customer/{id}");

            return result;
        }
    }
}
