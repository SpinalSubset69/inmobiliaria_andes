using InmobiliariaAndes.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmobiliariaAndes.Application.Extensions;
public static class ServiceAppExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Add Db Service
        var connectionString = 
            (Environment.GetEnvironmentVariable("Environment") ?? "") == "Local" ?
            Environment.GetEnvironmentVariable("ConnectionStrings__DbConnectionString") : config.GetConnectionString("DbConnectionString");
        services.AddAppDbContext(config.GetConnectionString("DbConnectionString") ?? throw new Exception("Connection string not found"));

        return services;
    }
}
