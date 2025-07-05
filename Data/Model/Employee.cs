using System;

namespace Data.Model;

public class Employee
{
    public Guid Id { get; set; }
    public Guid DepartmentId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Department Department { get; set; } = default!;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public Address Address { get; set; } = default!;
}
