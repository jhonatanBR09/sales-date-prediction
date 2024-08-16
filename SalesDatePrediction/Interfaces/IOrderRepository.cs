﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<int> AddOrderAsync(OrderDto order);        
        Task UpdateOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int orderId);
    }
}
