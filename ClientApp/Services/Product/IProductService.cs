using ClientApp.Dtos;

namespace ClientApp.Services.Product
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync();
    }
}
