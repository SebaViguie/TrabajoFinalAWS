using Microsoft.AspNetCore.Mvc;
using Order.Application.Dtos;
using Order.Application.Services.Order;
using Order.Domain.Entities;

namespace Order.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        private readonly IOrderService _service;

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderDto order)
        {
            await _service.AddOrderAsync(order);

            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int id)
        {
            var orders = await _service.GetOrdersByCustomerIdAsync(id);

            return Ok(orders);
        }
    }
}
