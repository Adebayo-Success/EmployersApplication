using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class EmployeeAppDbContext : IdentityDbContext<IdentityUser>
{

    public EmployeeAppDbContext(DbContextOptions<EmployeeAppDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Department> Departments { get; set; } = default!;
    public DbSet<Address> Addresses { get; set; } = default!;
    public DbSet<State> States { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Automatically apply all IEntityTypeConfiguration<T> from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeAppDbContext).Assembly);
    }
}
