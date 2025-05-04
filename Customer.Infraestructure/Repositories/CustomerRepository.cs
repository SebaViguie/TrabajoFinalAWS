using Customer.Domain.Entities;
using Customer.Domain.Repositories;
using Customer.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infraestructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        private readonly CustomerDbContext _context;
        public async Task<CustomerEntity> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            return customer;
        }

        public async Task<List<CustomerEntity>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task AddCustomerAsync(CustomerEntity customer)
        {
            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(CustomerEntity customer)
        {
            _context.Customers.Update(customer);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var result = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(result);

            await _context.SaveChangesAsync();
        }
    }
}
