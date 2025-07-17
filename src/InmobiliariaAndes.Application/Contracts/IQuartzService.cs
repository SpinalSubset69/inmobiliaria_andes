using InmobiliariaAndes.Domain.Entities;
using Quartz;

namespace InmobiliariaAndes.Application.Contracts;

public interface IQuartzService
{    
    Task ScheduleJob<T>(QuartzConfiguration config, T? jobArg = default) where T : IJob;
    Task UpdateJobConfigurationAsync(QuartzConfiguration config, long id);
}
