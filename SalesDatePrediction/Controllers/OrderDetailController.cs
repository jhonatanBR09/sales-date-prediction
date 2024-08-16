using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetOrderDetailsByOrderId(int orderId)
        {
            return Ok(await _orderDetailService.GetOrderDetailsByOrderIdAsync(orderId));
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetOrderDetailsByProductId(int productId)
        {
            return Ok(await _orderDetailService.GetOrderDetailsByProductIdAsync(productId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailDto orderDetail)
        {
            await _orderDetailService.AddOrderDetailAsync(orderDetail);
            return CreatedAtAction(nameof(GetOrderDetailById), new { orderId = orderDetail.OrderId, productId = orderDetail.ProductId }, orderDetail);
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderDetailDto>> GetOrderDetailById(int orderId, int productId)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(orderId, productId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailDto orderDetail)
        {
            await _orderDetailService.UpdateOrderDetailAsync(orderDetail);
            return NoContent();
        }

        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            await _orderDetailService.DeleteOrderDetailAsync(orderId, productId);
            return NoContent();
        }
    }
}
