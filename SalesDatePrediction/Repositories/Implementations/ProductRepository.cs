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
    public class ProductRepository : IProductRepository
    {
        private readonly DBDbContext _context;

        public ProductRepository(DBDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            return await _context.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDto
                {
                    ProductId = p.Id,
                    ProductName = p.ProductName

                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _context.Products
                .Select(p => new ProductDto
                {
                    ProductId = p.Id,
                    ProductName = p.ProductName
                })
                .ToListAsync();
        }
    }
}
