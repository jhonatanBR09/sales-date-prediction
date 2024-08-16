using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        public async Task AddCustomerAsync(CustomerDto customer)
        {
            
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
            
            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            
            await _customerRepository.DeleteCustomerAsync(customerId);
        }
        public async Task<List<CustomerWithOrderDatesDto>> GetCustomersWithOrderDatesAsync()
        {
            return await _customerRepository.GetCustomersWithOrderDatesAsync();
        }
    }
}
