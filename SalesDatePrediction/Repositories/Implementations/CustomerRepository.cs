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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DBDbContext _context;

        public CustomerRepository(DBDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var entity = new Customer
            {
                CompanyName = customerDto.CompanyName,
                ContactName = customerDto.ContactName,
                ContactTitle = customerDto.ContactTitle,
                Address = customerDto.Address,
                City = customerDto.City,
                Region = customerDto.Region,
                PostalCode = customerDto.PostalCode,
                Country = customerDto.Country,
                Phone = customerDto.Phone,
                Fax = customerDto.Fax
            };
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var entity = await _context.Customers.FindAsync(customerId);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers
                .Where(c => c.CustId == customerId)
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region,
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    Phone = c.Phone,
                    Fax = c.Fax
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustId,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName,
                    ContactTitle = c.ContactTitle,
                    Address = c.Address,
                    City = c.City,
                    Region = c.Region, 
                    PostalCode = c.PostalCode,
                    Country = c.Country,
                    Phone = c.Phone,
                    Fax = c.Fax
                })
                .ToListAsync();
        }

        public async Task<List<CustomerWithOrderDatesDto>> GetCustomersWithOrderDatesAsync()
        {
            // Consulta a la vista
            var result = await _context.CustomerWithOrderDatesDto.ToListAsync();
            return result;
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            var entity = await _context.Customers.FindAsync(customerDto.CustomerId);
            if (entity != null)
            {
                entity.CompanyName = customerDto.CompanyName;
                entity.ContactName = customerDto.ContactName;
                entity.ContactTitle = customerDto.ContactTitle;
                entity.Address = customerDto.Address;
                entity.City = customerDto.City;
                entity.Region = customerDto.Region;
                entity.PostalCode = customerDto.PostalCode;
                entity.Country = customerDto.Country;
                entity.Phone = customerDto.Phone;
                entity.Fax = customerDto.Fax;

                _context.Customers.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
