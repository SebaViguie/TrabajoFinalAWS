using ClientApp.Dtos;

namespace ClientApp.Services.Customer
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerDto customerDto);
    }
}
