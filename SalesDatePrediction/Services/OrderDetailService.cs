using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync()
        {
            return _orderDetailRepository.GetOrderDetailsAsync();
        }

        public Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return _orderDetailRepository.GetOrderDetailByIdAsync(orderId, productId);
        }

        public Task AddOrderDetailAsync(OrderDetailDto orderDetail)
        {
            return _orderDetailRepository.AddOrderDetailAsync(orderDetail);
        }

        public Task UpdateOrderDetailAsync(OrderDetailDto orderDetail)
        {
            return _orderDetailRepository.UpdateOrderDetailAsync(orderDetail);
        }

        public Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            return _orderDetailRepository.DeleteOrderDetailAsync(orderId, productId);
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _orderDetailRepository.GetOrderDetailsByOrderIdAsync(orderId);
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByProductIdAsync(int productId)
        {
            return await _orderDetailRepository.GetOrderDetailsByProductIdAsync(productId);
        }
    }
}
