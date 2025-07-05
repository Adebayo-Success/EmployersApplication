using System;
using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class StateService : IStateService
{
    private readonly EmployeeAppDbContext _context;

    public StateService(EmployeeAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<State>> GetAllStatesAsync()
    {
        return await _context.States.OrderBy(s => s.Name).ToListAsync();
    }
}
