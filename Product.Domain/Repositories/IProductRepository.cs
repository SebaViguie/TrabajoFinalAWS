using Product.Domain.Entities;

namespace Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetProductByIdAsync(int Id);
        Task<List<ProductEntity>> GetAllProductsAsync();
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int id);
    }
}