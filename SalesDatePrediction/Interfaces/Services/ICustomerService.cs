using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task AddCustomerAsync(CustomerDto customer);
        Task UpdateCustomerAsync(CustomerDto customer);
        Task DeleteCustomerAsync(int customerId);
        Task<List<CustomerWithOrderDatesDto>> GetCustomersWithOrderDatesAsync();
    }
}
