using Quartz;

namespace InmobiliariaAndes.Application.Jobs;

public class SendWhatsAppMessageJob : IJob
{    
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Executing SendWhatsAppMessageJob...");
        return Task.CompletedTask;
    }
}
