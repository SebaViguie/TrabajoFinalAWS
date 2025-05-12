using Product.Application.Dtos;
using Product.Domain.Entities;

namespace Product.Application.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<List<ProductEntity>> GetAllProductsAsync();
        Task AddProductAsync(ProductDto product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int id);
    }
}
