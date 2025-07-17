using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Application.Contracts;
using InmobiliariaAndes.Application.Services;
using InmobiliariaAndes.Application.Services.HostedServices;
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

        // Add unitOf work
        services.AddTransient<IAppUnitOfWork, AppUnitOfWork>();

        return services;
    }

    public static IServiceCollection AddApplicationHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<AppQuartzHostedService>();
        return services;
    }
}
