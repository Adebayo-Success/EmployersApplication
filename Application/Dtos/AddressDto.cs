using System;
using Data.Model;

namespace Application.Dtos;

public class AddressDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public int? StreetNumber { get; set; }
    public string StreetName { get; set; } = default!;
    public string City { get; set; } = default!;
    public  string Country { get; set; } = default!;
    public Guid StateId { get; set; }
    public State State { get; set; } = default!;
    public Employee? EmployeeFullName { get; set; }
}

public class CreateAddressDto
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid StateId { get; set; }
    public Employee Employee { get; set; } = default!;
    public int StreetNumber { get; set; }
    public string StreetName { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public State State { get; set; } = default!;
}

public class UpdateAddressDto
{
    public Guid EmployeeId { get; set; }
    public string StreetName { get; set; } = string.Empty;
    public string StreetNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public State State { get; set; } = default!;
    public string Country { get; set; } = string.Empty;
}
