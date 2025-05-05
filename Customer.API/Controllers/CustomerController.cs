using Customer.Application.Dtos;
using Customer.Application.Services;
using Customer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ICustomerService customerService)
        {
            _service = customerService;
        }

        private readonly ICustomerService _service;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _service.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDto customer)
        {
            await _service.AddCustomerAsync(customer);

            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerEntity customer)
        {
            await _service.UpdateCustomerAsync(customer);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _service.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}