using Microsoft.AspNetCore.Mvc;
using Product.Application.Dtos;
using Product.Application.Services;
using Product.Domain.Entities;

namespace Product.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        private readonly IProductService _service;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            await _service.AddProductAsync(product);

            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductEntity product)
        {
            await _service.UpdateProductAsync(product);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProductAsync(id);

            return NoContent();
        }
    }
}