using Order.Application.Dtos;

namespace Order.Application.Services.Product
{
    public interface IProductService
    {
        Task<ProductInfoDto> GetProductInfoAsync(int id);
        Task UpdateProductAsync(UpdateProductDto product);
    }
}
