using Data.Model;

namespace Application.Dtos;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Department Department { get; set; } = default!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
  
}

public class  EmployeesDto
{
    public List<EmployeeDto> Employees { get; set; } = default!;
}

public class CreateEmployeeDto
{
    public Guid DepartmentId { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Department { get; set; } = default!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
}
public class DetailEmployeeDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Departments { get; set; } = default!;
}
public class  EditEmployeeDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Departments { get; set; } = default!;
}