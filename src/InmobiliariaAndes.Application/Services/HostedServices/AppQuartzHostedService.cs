using InmobiliariaAndes.Application.Contracts;
using InmobiliariaAndes.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InmobiliariaAndes.Application.Services.HostedServices;

public class AppQuartzHostedService(
    ILogger<AppQuartzHostedService> logger,
     IServiceScopeFactory serviceScopeFactory
    ) : IHostedService, IDisposable
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Going to schedule Quartz jobs at {DateTime.Now}.");

        using IServiceScope scope = serviceScopeFactory.CreateScope();

        var appUnitOfWork = scope.ServiceProvider.GetRequiredService<IAppUnitOfWork>();
        var quartzService = scope.ServiceProvider.GetRequiredService<IQuartzService>();

        try
        {
            // Get all job types from the assembly with an active instance
            var jobTypes = this.GetType().Assembly.GetJobFromAssembly();

            // get all batches configurations from the repository
            var quartzConfigs = await appUnitOfWork.QuartzRepository.GetAllQuartzConfigurationsAsync();

            if (quartzConfigs.Any() == false)
            {
                logger.LogWarning("No Quartz configurations found. Skipping job scheduling.");
                return;
            }

            foreach (var job in jobTypes)
            {
                var getJobConfiguration = quartzConfigs.FirstOrDefault(x => x.ClassServiceName == job?.GetType().Name);
                if (getJobConfiguration == null)
                {
                    logger.LogInformation($"No configuration found for job {job?.GetType().Name}. Skipping...");
                    continue;
                }

                // schedule the job
                await quartzService.ScheduleJob(getJobConfiguration, job);
                logger
                .LogInformation($"Scheduled job {getJobConfiguration?.JobName} in group {getJobConfiguration?.JobGroup} with cron expression {getJobConfiguration?.CronExpression}.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while scheduling Quartz jobs.");
        }
        finally
        {
            appUnitOfWork.Dispose();
            Dispose();
        }

        // Logic to start the Quartz scheduler
        logger.LogInformation("Quartz Scheduler started successfully.");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // Logic to stop the Quartz scheduler
        logger.LogInformation("Stopping Quartz Scheduler...");
        return Task.CompletedTask;
    }

    public void Dispose(bool disposing)
    {
        if (!disposing) return;

        // Logic to dispose of resources if necessary        
        logger.LogInformation("Quartz Hosted Service disposed.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

