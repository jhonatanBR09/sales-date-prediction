using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        Task AddCustomerAsync(CustomerDto customer);
        Task UpdateCustomerAsync(CustomerDto customer);
        Task DeleteCustomerAsync(int customerId);
        Task<List<CustomerWithOrderDatesDto>> GetCustomersWithOrderDatesAsync();
    }
}
