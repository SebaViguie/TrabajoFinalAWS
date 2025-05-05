using Customer.Application.Dtos;
using Customer.Domain.Entities;

namespace Customer.Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task AddCustomerAsync(CustomerDto customer);
        Task UpdateCustomerAsync(CustomerEntity customer);
        Task DeleteCustomerAsync(int id);
    }
}
