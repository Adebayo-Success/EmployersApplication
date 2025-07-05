using Application.Dtos;

namespace Application.Services.Employee;

public interface IEmployeeServices
{
    Task<EmployeesDto> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(Guid empId);
    Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto createEmpDto);
    Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto dt, Guid Id);
    Task DeleteEmployeeAsync(Guid id);
}


