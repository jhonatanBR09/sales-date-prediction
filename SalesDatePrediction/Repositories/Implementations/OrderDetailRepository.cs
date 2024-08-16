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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DBDbContext _context;

        public OrderDetailRepository(DBDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsAsync()
        {
            return await _context.OrderDetails
                .Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })
                .ToListAsync();
        }

        public async Task<OrderDetailDto> GetOrderDetailByIdAsync(int orderId, int productId)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId && od.ProductId == productId)
                .Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDetailDto>> GetOrderDetailsByProductIdAsync(int productId)
        {
            return await _context.OrderDetails
                .Where(od => od.ProductId == productId)
                .Select(od => new OrderDetailDto
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })
                .ToListAsync();
        }

        public async Task AddOrderDetailAsync(OrderDetailDto orderDetail)
        {
            var entity = new OrderDetail
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                UnitPrice = orderDetail.UnitPrice,
                Quantity = orderDetail.Quantity,
                Discount = orderDetail.Discount
            };
            _context.OrderDetails.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetailDto orderDetail)
        {
            var entity = await _context.OrderDetails
                .FindAsync(orderDetail.OrderId, orderDetail.ProductId);

            if (entity != null)
            {
                entity.UnitPrice = orderDetail.UnitPrice;
                entity.Quantity = orderDetail.Quantity;
                entity.Discount = orderDetail.Discount;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            var entity = await _context.OrderDetails
                .FindAsync(orderId, productId);

            if (entity != null)
            {
                _context.OrderDetails.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
