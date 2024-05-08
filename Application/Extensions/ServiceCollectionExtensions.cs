using Application.Services;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection collection)
        {
            collection.AddScoped<ISetupService, SetupService>();
            collection.AddScoped<ILoginService, LoginService>();
            collection.AddScoped<IEmployeeService, EmployeeService>();
            collection.AddScoped<IManagerService, ManagerService>();

            return collection;
        }
    }
}
