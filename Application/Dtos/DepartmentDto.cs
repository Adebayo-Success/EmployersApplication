
namespace Application.Dtos;

public class DepartmentDto
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public IEnumerable<EmployeeDto> Employees { get; set; } = [];
}

public class DepartmentsDto
{
    public List<DepartmentDto> Departments { get; set; } = default!;
}

public class CreateDepartmentDto
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
public class DetailDepartmentDto
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
public class EditDepartmentDto
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; } 
}
