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
    public class ShipperRepository : IShipperRepository
    {
        private readonly DBDbContext _context;

        public ShipperRepository(DBDbContext context)
        {
            _context = context;
        }

        public async Task<ShipperDto> GetShipperByIdAsync(int shipperId)
        {
            return await _context.Shippers
                .Where(s => s.ShipperId == shipperId)
                .Select(s => new ShipperDto
                {
                    ShipperId = s.ShipperId,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShipperDto>> GetShippersAsync()
        {
            return await _context.Shippers
                .Select(s => new ShipperDto
                {
                    ShipperId = s.ShipperId,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone
                })
                .ToListAsync();
        }
    }
}
