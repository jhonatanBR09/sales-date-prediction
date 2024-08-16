using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByCustomerId(int customerId)
        {
            return Ok(await _orderService.GetOrdersByCustomerIdAsync(customerId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            var orderId = await _orderService.AddOrderAsync(order);            
            order.OrderId = orderId;

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, order);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderDto order)
        {
            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
