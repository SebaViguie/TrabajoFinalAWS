using AutoMapper;
using Product.Application.Dtos;
using Product.Domain.Entities;
using Product.Domain.Repositories;
using Product.Domain.Validations;

namespace Product.Application.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository productRepository, IMapper mapper, ProductValidator validator)
        {
            _repository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ProductValidator _validator;

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            var result = _mapper.Map<ProductDto>(product);

            return result;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllProductsAsync();

            var result = _mapper.Map<List<ProductDto>>(products);

            return result;
        }

        public async Task AddProductAsync(ProductDto product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            var productValidator = _validator.Validate(productEntity);

            if (!productValidator.IsValid)
            {
                throw new Exception(productValidator.Errors.First().ErrorMessage);
            }

            await _repository.AddProductAsync(productEntity);
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
