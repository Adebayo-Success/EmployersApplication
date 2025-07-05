using System;
using Data.Migrations;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
       public void Configure(EntityTypeBuilder<Address> builder)
       {
              builder.HasKey(a => a.Id);

              // One-to-one: One employee has one address
              builder.HasOne(a => a.Employee)
                     .WithOne(e => e.Address)
                     .HasForeignKey<Address>(a => a.EmployeeId)
                     .OnDelete(DeleteBehavior.Cascade); // if employee is deleted, delete address

              builder.Property(a => a.StreetNumber).HasMaxLength(100);
              builder.Property(a => a.StreetName).HasMaxLength(100);
              builder.Property(a => a.City).HasMaxLength(50);
              builder.Property(a => a.State).HasMaxLength(50);
              builder.Property(a => a.Country).HasMaxLength(50);
       }

}
