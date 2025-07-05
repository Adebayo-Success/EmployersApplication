using System;
using Application.Dtos;
using Data.Model;
namespace Application.Services;

public interface IAddressService
{
    Task<AddressDto> AddAddressAsync(CreateAddressDto address);
    // Task<List<State>> GetAllStatesAsync();
    Task<AddressDto> GetAddressByEmployeeIdAsync(Guid employeeId);
    Task<AddressDto> UpdateAddressAsync(AddressDto address, Guid employeeId);
    Task DeleteAddressAsync(Guid id);
}