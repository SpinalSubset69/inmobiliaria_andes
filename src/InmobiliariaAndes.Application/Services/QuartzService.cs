using InmobiliariaAndes.Application.Contracts;
using InmobiliariaAndes.Domain.Constants;
using InmobiliariaAndes.Domain.Entities;
using Microsoft.Extensions.Logging;
using Quartz;

namespace InmobiliariaAndes.Application.Services;

public class QuartzService(ILogger<QuartzService> logger, ISchedulerFactory schedulerFactory) : IQuartzService
{    
    public async Task ScheduleJob<T>(QuartzConfiguration config, T? jobArg = default) where T : IJob
    {
        await _SchuduleJob<T>(config, jobArg);
    }

    public Task UpdateJobConfigurationAsync(QuartzConfiguration config, long id)
    {
        throw new NotImplementedException();
    }

    private async Task _SchuduleJob<T>(QuartzConfiguration config, T? jobarg = default) where T : IJob
    {
        // Implementation for scheduling a job with the given configuration
        var jobType = typeof(T);

        logger.LogInformation($"Scheduling job {jobType.Name} with configuration: {config.CronExpression}");

        var scheduler = await schedulerFactory.GetScheduler(QuartzConstants.SchedulerName);

        if (scheduler is null)
        {
            logger.LogError("Scheduler is null. Cannot schedule job.");
            throw new InvalidOperationException("Scheduler is not initialized.");
        }

        // TODO: later add params dynamically from config object
        var job = JobBuilder.Create<T>()
        .WithIdentity($"{config.JobName}-Job", config.JobGroup)
        .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity($"{config.JobName}-Trigger", config.JobGroup)
            .WithCronSchedule(config.CronExpression)
            .Build();

        await scheduler.ScheduleJob(job, trigger);

        logger.LogInformation($"Job {jobType.Name} scheduled successfully with cron expression: {config.CronExpression}");
    }
}
