using Application.Dtos;
using Data.Model;

namespace Application.ContractMapping;

public static class Mapper
{
    public static EmployeeDto EmpToDto(this Employee employee)
    {
        if (employee == null)
        {
            return null!;
        }

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

    public static Employee EmpToModel(this CreateEmployeeDto createEmployeeDto)
    {
        if (createEmployeeDto == null)
        {
            return null!;
        }
        return new Employee
        {
            DepartmentId = createEmployeeDto.DepartmentId,
            FirstName = createEmployeeDto.FirstName,
            LastName = createEmployeeDto.LastName,
            Email = createEmployeeDto.Email,
            HireDate = createEmployeeDto.HireDate,
            Salary = createEmployeeDto.Salary
        };
    }

    public static EmployeesDto EmployeesDto(this List<Employee> employees)
    {
        if (employees == null || !employees.Any())
        {
            return null!;
        }
        return new EmployeesDto()
        {
            Employees = employees.Select(d => d.EmpToDto()).ToList()
        };
    }
    //Department Marping
    public static DepartmentDto ToDto(this Department department)
    {
        if (department == null)
        {
            return null!;
        }

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description
        };
    }

    public static Department ToModel(this CreateDepartmentDto createDepartmentDto)
    {
        if (createDepartmentDto == null)
        {
            return null!;
        }
        return new Department
        {
            Id = Guid.NewGuid(),
            Name = createDepartmentDto.Name,
            Description = createDepartmentDto.Description
        };
    }

    public static DepartmentsDto DepartmentsDto(this List<Department> departments)
    {
        if (departments == null || !departments.Any())
        {
            return null!;
        }
        return new DepartmentsDto
        {
            Departments = departments.Select(d => d.ToDto()).ToList()
        };
    }

//Address Mapper
    public static AddressDto AddToDto(this Address add)
    {
        if (add == null)
        {
            return null!;
        }

        return new AddressDto
        {
            EmployeeId = add.EmployeeId,
            StreetNumber = add.StreetNumber,
            StreetName = add.StreetName,
            City = add.City,
            StateId = add.StateId,
            State = add.State,
            Country = add.Country
        };
    }

    public static Address AddToModel(this CreateAddressDto createAddressDto)
    {
        if (createAddressDto == null)
        {
            return null!;
        }
        return new Address
        {
            EmployeeId = createAddressDto.EmployeeId,
            StreetNumber = createAddressDto.StreetNumber,
            StreetName = createAddressDto.StreetName,
            City = createAddressDto.City,
            StateId = createAddressDto.StateId,
            State = createAddressDto.State,
            Country = createAddressDto.Country
        };
    }
}