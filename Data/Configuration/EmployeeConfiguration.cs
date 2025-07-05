using System;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;


public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(a => a.Id); // Primary key

        builder.Property(a => a.FirstName)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(a => a.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.Email)
               .HasMaxLength(100);

        builder.Property(a => a.HireDate);

        builder.Property(a => a.Salary)
                .IsRequired()
                .HasMaxLength(200);

        builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Address)
               .WithOne(a => a.Employee)
               .HasForeignKey<Address>(a => a.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade); //delete address when employee is deleted
    }
}