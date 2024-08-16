using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;
using SalesDatePrediction.Repositories.Implementations;
using SalesDatePrediction.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("with-order-dates")]
        public async Task<ActionResult<List<CustomerWithOrderDatesDto>>> GetCustomersWithOrderDates()
        {
            var customers = await _customerService.GetCustomersWithOrderDatesAsync();
            return Ok(customers);
        }
    }
}
