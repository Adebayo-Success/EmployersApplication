using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ContractMapping;
using Application.Dtos;
using Application.Services;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

public class AddressService : IAddressService
{
    private readonly EmployeeAppDbContext _context;

    public AddressService(EmployeeAppDbContext context)
    {
        _context = context;
    }

    public async Task<AddressDto?> GetAddressByEmployeeIdAsync(Guid employeeId)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.EmployeeId == employeeId);

        if (address == null)
        {
            return null;
        }
        return new AddressDto
        {
            EmployeeId = address.EmployeeId,
            StreetNumber = address.StreetNumber,
            StreetName = address.StreetName,
            City = address.City,
            StateId = address.StateId,
            State = address.State,
            Country = address.Country
        };
    }

    public async Task<AddressDto> AddAddressAsync(CreateAddressDto dto)
    {
        var data = new CreateAddressDto
        {
            StreetNumber = dto.StreetNumber,
            StreetName = dto.StreetName,
            City = dto.City,
            StateId = dto.StateId,
            State = dto.State,
            Country = dto.Country
        };

        var address = data.AddToModel();

        try
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return address.AddToDto();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the department.", ex);
            return new AddressDto();
        }
    }

    public async Task<AddressDto> UpdateAddressAsync(AddressDto addressDto, Guid id)
    {
        var address = await _context.Addresses.FindAsync(addressDto.EmployeeId) ?? throw new KeyNotFoundException();
        address.StreetNumber = addressDto.StreetNumber;
        address.StreetName = addressDto.StreetName;
        address.City = addressDto.City;
        address.StateId = addressDto.StateId;
        address.State = addressDto.State;
        address.Country = addressDto.Country;
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
        return new AddressDto
        {
            StreetNumber = address.StreetNumber,
            StreetName = address.StreetName,
            City = address.City,
            StateId = address.StateId,
            State = address.State,
            Country = address.Country
        };
    }

    public async Task DeleteAddressAsync(Guid id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address != null)
        {
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
