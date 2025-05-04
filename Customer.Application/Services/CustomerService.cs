using Customer.Domain.Entities;
using Customer.Domain.Repositories;

namespace Customer.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository)
        {
            _repository = customerRepository;
        }

        private readonly ICustomerRepository _repository;

        public async Task<CustomerEntity> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);

            return customer;
        }
        public async Task<List<CustomerEntity>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllCustomersAsync();

            return customers;
        }
        public async Task AddCustomerAsync(CustomerEntity customer)
        {
            await _repository.AddCustomerAsync(customer);
        }
        public async Task UpdateCustomerAsync(CustomerEntity customer)
        {
            await _repository.UpdateCustomerAsync(customer);
        }
        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteCustomerAsync(id);
        }
    }
}