namespace Data.Model;

public class Address
{
    public Guid Id { get; set; }
    public int? StreetNumber { get; set; }
    public required string StreetName { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public int StateId { get; set; }
    public required State State { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;
}
