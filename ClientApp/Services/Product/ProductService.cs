using ClientApp.Dtos;

namespace ClientApp.Services.Product
{
    public class ProductService : IProductService
    {
        public ProductService(HttpClient client)
        {
            _client = client;
        }

        private readonly HttpClient _client;

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var response = await _client.GetFromJsonAsync<List<ProductDto>>("product");

            return response ?? new List<ProductDto>();
        }
    }
}
