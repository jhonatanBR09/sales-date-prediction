using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId);
        Task AddEmployeeAsync(EmployeeDto employee);
        Task UpdateEmployeeAsync(EmployeeDto employee);
        Task DeleteEmployeeAsync(int employeeId);
    }
}
