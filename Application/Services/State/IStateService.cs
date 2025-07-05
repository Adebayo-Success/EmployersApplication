using System;
using Data.Model;

namespace Application.Services;

public interface IStateService
{
    Task<List<State>> GetAllStatesAsync();
}
