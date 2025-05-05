using Order.Application.Dtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace Order.Application.Services.Product
{
    public class ProductService : IProductService
    {
        public async Task<ProductInfoDto> GetProductInfoAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7004/");
            var result = await client.GetFromJsonAsync<ProductInfoDto>($"product/{id}");

            return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7004/");
            await client.PutAsJsonAsync($"product", product);
        }
    }
}
