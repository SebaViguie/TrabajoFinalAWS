using Product.Domain.Entities;

namespace Product.Application.Services
{
    public interface IProductService
    {
        Task<ProductEntity> GetProductByIdAsync(int id);
        Task<List<ProductEntity>> GetAllProductsAsync();
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int id);
    }
}
