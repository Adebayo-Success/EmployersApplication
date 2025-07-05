using Application.ContractMapping;
using Application.Dtos;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Application.Services.Department;

public class DepartmentService : IDepartmentService
{
    private readonly EmployeeAppDbContext _context;

    public DepartmentService(EmployeeAppDbContext context)
    {
        _context = context;
    }

    public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        var data = new CreateDepartmentDto
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description
        };

        var department = data.ToModel();

        try
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return department.ToDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the department.", ex);
            return new DepartmentDto();
        }
    }
    public async Task DeleteDepartmentAsync(Guid departmentId)
    {
        try
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                var emp = await _context.SaveChangesAsync() > 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the department.", ex);
        }
    }

    public async Task<DepartmentsDto> GetAllDepartmentsAsync()
    {
        var departments = await _context.Departments.ToListAsync();

        return departments.DepartmentsDto();
    }

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    public async Task<DepartmentDto?> GetDepartmentByIdAsync(Guid departmentId)
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == departmentId);

        if (department == null)
        {
            return null;
        }
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description
        };
    }

    public async Task<DepartmentDto> UpdateDepartmentAsync(DepartmentDto departmentDto, Guid id)
    {
        var department = await _context.Departments.FindAsync(departmentDto.Id) ?? throw new KeyNotFoundException();
        department.Name = departmentDto.Name;
        department.Description = departmentDto.Description;
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description
        };
    }
}
