using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Context;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;
using SalesDatePrediction.Models.Entities;

namespace SalesDatePrediction.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DBDbContext _context;

        public OrderRepository(DBDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddOrderAsync(OrderDto orderDto)
        {
            var entity = new Order
            {
                CustomerId = orderDto.CustomerId,
                EmployeeId = orderDto.EmployeeId,
                OrderDate = orderDto.OrderDate,
                RequiredDate = orderDto.RequiredDate,
                ShippedDate = orderDto.ShippedDate,
                ShipperId = orderDto.ShipperId,
                Freight = orderDto.Freight,
                ShipName = orderDto.ShipName,
                ShipAddress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipRegion = orderDto.ShipRegion,
                ShipPostalCode = orderDto.ShipPostalCode,
                ShipCountry = orderDto.ShipCountry
            };
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity.orderid;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var entity = await _context.Orders.FindAsync(orderId);
            if (entity != null)
            {
                _context.Orders.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Where(o => o.orderid == orderId)
                .Select(o => new OrderDto
                {
                    OrderId = o.orderid,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipperId = o.ShipperId,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipRegion = o.ShipRegion,
                    ShipPostalCode = o.ShipPostalCode,
                    ShipCountry = o.ShipCountry
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            return await _context.Orders
                .Select(o => new OrderDto
                {
                    OrderId = o.orderid,
                    CustomerId = o.CustomerId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipperId = o.ShipperId,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipRegion = o.ShipRegion,
                    ShipPostalCode = o.ShipPostalCode,
                    ShipCountry = o.ShipCountry
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Select(o => new OrderDto
                {
                    OrderId = o.orderid,
                    CustomerId = o.CustomerId,
                    EmployeeId = o.EmployeeId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipperId = o.ShipperId,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipRegion = o.ShipRegion,
                    ShipPostalCode = o.ShipPostalCode,
                    ShipCountry = o.ShipCountry
                })
                .ToListAsync();
        }

        public async Task UpdateOrderAsync(OrderDto orderDto)
        {
            var entity = await _context.Orders.FindAsync(orderDto.OrderId);
            if (entity != null)
            {
                entity.CustomerId = orderDto.CustomerId;
                entity.EmployeeId = orderDto.EmployeeId;
                entity.OrderDate = orderDto.OrderDate;
                entity.RequiredDate = orderDto.RequiredDate;
                entity.ShippedDate = orderDto.ShippedDate;
                entity.ShipperId = orderDto.ShipperId;
                entity.Freight = orderDto.Freight;
                entity.ShipName = orderDto.ShipName;
                entity.ShipAddress = orderDto.ShipAddress;
                entity.ShipCity = orderDto.ShipCity;
                entity.ShipRegion = orderDto.ShipRegion;
                entity.ShipPostalCode = orderDto.ShipPostalCode;
                entity.ShipCountry = orderDto.ShipCountry;

                _context.Orders.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
