using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Repositories;
using Product.Infraestructure.Data;

namespace Product.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        private readonly ProductDbContext _context;

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product;
        }
        public async Task<List<ProductEntity>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
        public async Task AddProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();            
        }
        public async Task UpdateProductAsync(ProductEntity product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var result = await _context.Products.FindAsync(id);

            _context.Products.Remove(result);

            await _context.SaveChangesAsync();
        }
    }
}