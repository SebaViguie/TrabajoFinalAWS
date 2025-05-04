
using Product.Domain.Entities;
using Product.Domain.Repositories;

namespace Product.Application.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        private readonly IProductRepository _repository;

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            return product;
        }

        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllProductsAsync();

            return products;
        }

        public async Task AddProductAsync(ProductEntity product)
        {
            await _repository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductEntity product)
        {
            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }
    }
}
