using AutoMapper;
using Customer.Application.Dtos;
using Customer.Domain.Entities;
using Customer.Domain.Repositories;

namespace Customer.Application.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _repository = customerRepository;
            _mapper = mapper;
        }

        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);

            var result = _mapper.Map<CustomerDto>(customer);

            return result;
        }
        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.GetAllCustomersAsync();

            var result = _mapper.Map<List<CustomerDto>>(customers);

            return result;
        }
        public async Task AddCustomerAsync(CustomerDto customer)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(customer);

            await _repository.AddCustomerAsync(customerEntity);
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