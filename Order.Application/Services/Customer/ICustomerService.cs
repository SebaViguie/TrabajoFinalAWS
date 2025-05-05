using Order.Application.Dtos;

namespace Order.Application.Services.Customer
{
    public interface ICustomerService
    {
        Task<CustomerInfoDto> GetCustomerInfoAsync(int id);
    }
}
