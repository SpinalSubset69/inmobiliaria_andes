using InmobiliariaAndes.Application.Contracts;
using InmobiliariaAndes.Application.Services;
using InmobiliariaAndes.Domain.Constants;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Quartz;

namespace InmobiliariaAndes.API.Configurations.ServiceCollectionExtensions;

public static class QuartzServiceConfiguration
{
    public static IServiceCollection AddQuartzService(this IServiceCollection services)
    {
        // Register Quartz services and jobs here
        services.AddQuartz(q =>
        {
            q.SchedulerName = QuartzConstants.SchedulerName;
        });

        services.AddQuartzHostedService(q =>
        {
            q.AwaitApplicationStarted = true;
            q.WaitForJobsToComplete = true;
        });

        services.AddOpenTelemetry()
            .WithTracing(tracing =>
            {
                tracing
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation()
                .AddQuartzInstrumentation();
            })
        .UseOtlpExporter();

        services.AddSingleton<IQuartzService, QuartzService>(); // Singleton so that we can use it whithin hosted services

        return services;
    }
}
