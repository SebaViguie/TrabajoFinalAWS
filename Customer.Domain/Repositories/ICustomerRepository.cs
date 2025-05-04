using Customer.Domain.Entities;

namespace Customer.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerEntity> GetCustomerByIdAsync(int id);
        Task<List<CustomerEntity>> GetAllCustomersAsync();
        Task AddCustomerAsync(CustomerEntity customer);
        Task UpdateCustomerAsync(CustomerEntity customer);
        Task DeleteCustomerAsync(int id);
    }
}
