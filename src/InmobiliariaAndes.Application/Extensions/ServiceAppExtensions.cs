using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmobiliariaAndes.Application.Extensions;
public static class ServiceAppExtensions
{
    [ExcludeFromCodeCoverage]
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Add Db Service
        var connectionString =
            (Environment.GetEnvironmentVariable("Environment") ?? "") == "Local" ?
            Environment.GetEnvironmentVariable("ConnectionStrings__DbConnectionString") : config.GetConnectionString("DbConnectionString");
        services.AddAppDbContext(connectionString ?? throw new Exception("Connection string not found"));

        return services;
    }
}
