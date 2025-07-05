using Application.Services.Department;
using Application.Services.Employee;
using Application.Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Configuration;
using Application.Services.Cloudinary;
using System.Configuration;
using Application.Services;

namespace Application;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IEmployeeServices, EmployeeServices>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IEmailSender, EmailSender>();
        return services;
    }
}
