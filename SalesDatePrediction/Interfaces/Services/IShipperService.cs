using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperDto>> GetShippersAsync();
        Task<ShipperDto> GetShipperByIdAsync(int shipperId);
    }
}
