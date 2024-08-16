using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync();
        Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderId, int productId);
        Task AddOrderDetailAsync(OrderDetailDto orderDetail);
        Task UpdateOrderDetailAsync(OrderDetailDto orderDetail);
        Task DeleteOrderDetailAsync(int orderId, int productId);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByProductIdAsync(int productId);
    }
}
