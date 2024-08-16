using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<int> AddOrderAsync(OrderDto order);
        Task UpdateOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
    }
}
