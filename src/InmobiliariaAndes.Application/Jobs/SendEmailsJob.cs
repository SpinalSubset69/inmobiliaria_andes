using Quartz;

namespace InmobiliariaAndes.Application.Jobs;

public class SendEmailsJob : IJob
{    
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Executing SendEmailsJob...");
        return Task.CompletedTask;
    }
}
