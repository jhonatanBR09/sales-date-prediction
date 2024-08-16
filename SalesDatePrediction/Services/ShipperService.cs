using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<IEnumerable<ShipperDto>> GetShippersAsync()
        {
            return await _shipperRepository.GetShippersAsync();
        }

        public async Task<ShipperDto> GetShipperByIdAsync(int shipperId)
        {
            return await _shipperRepository.GetShipperByIdAsync(shipperId);
        }
    }
}
