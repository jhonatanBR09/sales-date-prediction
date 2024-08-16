using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            return _orderRepository.GetOrdersAsync();
        }

        public Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            return _orderRepository.GetOrderByIdAsync(orderId);
        }

        public Task<int> AddOrderAsync(OrderDto order)
        {
            return _orderRepository.AddOrderAsync(order);
        }

        public Task UpdateOrderAsync(OrderDto order)
        {
            return _orderRepository.UpdateOrderAsync(order);
        }

        public Task DeleteOrderAsync(int orderId)
        {
            return _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }
    }
}
