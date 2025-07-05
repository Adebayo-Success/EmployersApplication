using System;

namespace Data.Configuration;

using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired();

        // Seeding Nigerian States
        builder.HasData(
        new State { Id = 1, Name = "Abia", Code = "AB" },
        new State { Id = 2, Name = "Adamawa", Code = "AD" },
        new State { Id = 3, Name = "Akwa Ibom", Code = "AK" },
        new State { Id = 4, Name = "Anambra", Code = "AN" },
        new State { Id = 5, Name = "Bauchi", Code = "BA" },
        new State { Id = 6, Name = "Bayelsa", Code = "BY" },
        new State { Id = 7, Name = "Benue", Code = "BN" },
        new State { Id = 8, Name = "Borno", Code = "BO" },
        new State { Id = 9, Name = "Cross River", Code = "CR" },
        new State { Id = 10, Name = "Delta", Code = "DE" },
        new State { Id = 11, Name = "Ebonyi", Code = "EB" },
        new State { Id = 12, Name = "Edo", Code = "ED" },
        new State { Id = 13, Name = "Ekiti", Code = "EK" },
        new State { Id = 14, Name = "Enugu", Code = "EN" },
        new State { Id = 15, Name = "Gombe", Code = "GO" },
        new State { Id = 16, Name = "Imo", Code = "IM" },
        new State { Id = 17, Name = "Jigawa", Code = "JI" },
        new State { Id = 18, Name = "Kaduna", Code = "KD" },
        new State { Id = 19, Name = "Kano", Code = "KN" },
        new State { Id = 20, Name = "Katsina", Code = "KT" },
        new State { Id = 21, Name = "Kebbi", Code = "KE" },
        new State { Id = 22, Name = "Kogi", Code = "KO" },
        new State { Id = 23, Name = "Kwara", Code = "KW" },
        new State { Id = 24, Name = "Lagos", Code = "LA" },
        new State { Id = 25, Name = "Nasarawa", Code = "NA" },
        new State { Id = 26, Name = "Niger", Code = "NI" },
        new State { Id = 27, Name = "Ogun", Code = "OG" },
        new State { Id = 28, Name = "Ondo", Code = "ON" },
        new State { Id = 29, Name = "Osun", Code = "OS" },
        new State { Id = 30, Name = "Oyo", Code = "OY" },
        new State { Id = 31, Name = "Plateau", Code = "PL" },
        new State { Id = 32, Name = "Rivers", Code = "RI" },
        new State { Id = 33, Name = "Sokoto", Code = "SO" },
        new State { Id = 34, Name = "Taraba", Code = "TA" },
        new State { Id = 35, Name = "Yobe", Code = "YO" },
        new State { Id = 36, Name = "Zamfara", Code = "ZA" },
        new State { Id = 37, Name = "Federal Capital Territory", Code = "FCT" }
        );
    }
}
