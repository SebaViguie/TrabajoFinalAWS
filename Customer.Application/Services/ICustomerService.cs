using Customer.Domain.Entities;

namespace Customer.Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerEntity> GetCustomerByIdAsync(int id);
        Task<List<CustomerEntity>> GetAllCustomersAsync();
        Task AddCustomerAsync(CustomerEntity customer);
        Task UpdateCustomerAsync(CustomerEntity customer);
        Task DeleteCustomerAsync(int id);
    }
}
