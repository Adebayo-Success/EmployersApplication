using System;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(a => a.Id); // Primary key

        builder.Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(a => a.Description)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(e => e.Employees)
               .WithOne(a => a.Department)
               .HasForeignKey(a => a.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade); //delete address when employee is deleted
    }
}