using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;

        public ShipperController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipperDto>>> GetShippers()
        {
            return Ok(await _shipperService.GetShippersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipperDto>> GetShipperById(int id)
        {
            var shipper = await _shipperService.GetShipperByIdAsync(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return Ok(shipper);
        }
    }
}
