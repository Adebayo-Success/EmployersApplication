using Application.Dtos;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Application.ContractMapping;
namespace Application.Services.Employee;

public class EmployeeServices : IEmployeeServices
{
    private readonly EmployeeAppDbContext _context;

    public EmployeeServices(EmployeeAppDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto dto)
    {
        var data = new CreateEmployeeDto
        {
            DepartmentId = dto.DepartmentId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            HireDate = dto.HireDate,
            Salary = dto.Salary
        };

        var employee = data.EmpToModel();

        try
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee.EmpToDto();

        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the employee.", ex);
            return new EmployeeDto();
        }
    }
    public async Task DeleteEmployeeAsync(Guid id)
    {
        try
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                var emp = await _context.SaveChangesAsync() > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the employee.", ex);
        }
    }
    public async Task<EmployeesDto> GetAllEmployeesAsync()
    {
        var emp = await _context.Employees.ToListAsync();

        return emp.EmployeesDto();
    }

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    public async Task<EmployeeDto?> GetEmployeeByIdAsync(Guid id)
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    {
        var emp = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        if (emp == null)
        {
            return null;
        }
        return new EmployeeDto
        {
            Id = emp.Id,
            FirstName = emp.FirstName,
            LastName = emp.LastName,
            Email = emp.Email,
            Department = emp.Department,
            HireDate = emp.HireDate,
            Salary = emp.Salary
        };
    }

    public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto editEmployeeDtoDto, Guid id)
    {
        var employee = await _context.Employees.FindAsync(editEmployeeDtoDto.Id) ?? throw new KeyNotFoundException();
        employee.FirstName = editEmployeeDtoDto.FirstName;
        employee.LastName = editEmployeeDtoDto.LastName;
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return new EmployeeDto
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Department = employee.Department,
            HireDate = employee.HireDate,
            Salary = employee.Salary
        };
    }
}

