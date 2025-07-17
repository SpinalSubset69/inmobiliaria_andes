using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Application.Contracts;
using InmobiliariaAndes.Application.Services;
using InmobiliariaAndes.Application.Services.HostedServices;
using InmobiliariaAndes.Infrastructure.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InmobiliariaAndes.Application.Extensions;

public static class ServiceAppExtensions
{
    [ExcludeFromCodeCoverage]
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        // Add Db Service
        var dataSource = config.GetValue<string>("DataBase:DataSource") ?? Environment.GetEnvironmentVariable("DATASOURCE");
        var userId = config.GetValue<string>("DataBase:UserId") ?? Environment.GetEnvironmentVariable("USERID");
        var password = config.GetValue<string>("DataBase:Password") ?? Environment.GetEnvironmentVariable("PASSWORD");
        var initialCatalog = config.GetValue<string>("DataBase:InitialCatalog") ?? Environment.GetEnvironmentVariable("INITIALCATALOG");

        var connectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = dataSource,
            UserID = userId,
            Password = password,
            InitialCatalog = initialCatalog,
            TrustServerCertificate = true
        };
        
        services.AddAppDbContext(connectionStringBuilder.ConnectionString ?? throw new Exception("Connection string not found"));

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
