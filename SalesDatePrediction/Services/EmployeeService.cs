using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return _employeeRepository.GetEmployeesAsync();
        }

        public Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId)
        {
            return _employeeRepository.GetEmployeeByIdAsync(employeeId);
        }

        public Task AddEmployeeAsync(EmployeeDto employee)
        {
            return _employeeRepository.AddEmployeeAsync(employee);
        }

        public Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            return _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public Task DeleteEmployeeAsync(int employeeId)
        {
            return _employeeRepository.DeleteEmployeeAsync(employeeId);
        }
    }
}
