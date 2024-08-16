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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBDbContext _context;

        public EmployeeRepository(DBDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees
                .Where(e => e.EmpId == employeeId)
                .Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmpId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    BirthDate = e.BirthDate,
                    HireDate = e.HireDate,
                    Address = e.Address,
                    City = e.City,
                    Region = e.Region,
                    PostalCode = e.PostalCode,
                    Country = e.Country,
                    Phone = e.Phone,
                    ManagerId = e.ManagerId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmpId,
                    LastName = e.LastName,
                    FirstName = e.FirstName,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    BirthDate = e.BirthDate,
                    HireDate = e.HireDate,
                    Address = e.Address,
                    City = e.City,
                    Region = e.Region,
                    PostalCode = e.PostalCode,
                    Country = e.Country,
                    Phone = e.Phone,
                    ManagerId = e.ManagerId
                })
                .ToListAsync();
        }

        public async Task AddEmployeeAsync(EmployeeDto employee)
        {
            var entity = new Employee
            {
                EmpId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                Phone = employee.Phone,
                ManagerId = employee.ManagerId
            };
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            var entity = await _context.Employees.FindAsync(employee.EmployeeId);
            if (entity != null)
            {
                entity.LastName = employee.LastName;
                entity.FirstName = employee.FirstName;
                entity.Title = employee.Title;
                entity.TitleOfCourtesy = employee.TitleOfCourtesy;
                entity.BirthDate = employee.BirthDate;
                entity.HireDate = employee.HireDate;
                entity.Address = employee.Address;
                entity.City = employee.City;
                entity.Region = employee.Region;
                entity.PostalCode = employee.PostalCode;
                entity.Country = employee.Country;
                entity.Phone = employee.Phone;
                entity.ManagerId = employee.ManagerId;

                _context.Employees.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var entity = await _context.Employees.FindAsync(employeeId);
            if (entity != null)
            {
                _context.Employees.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
