using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IShipperRepository
    {
        Task<IEnumerable<ShipperDto>> GetShippersAsync();
        Task<ShipperDto> GetShipperByIdAsync(int shipperId);
    }
}
