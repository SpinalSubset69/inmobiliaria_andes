namespace InmobiliariaAndes.Domain.Entities;

public class QuartzConfiguration : BaseEntity
{
    /// <summary>
    /// Name to display in the UI
    /// </summary>
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string JobGroup { get; set; } = string.Empty;
    /// <summary>
    /// The name of the job within Quartz schedule
    /// </summary>
    public string JobName { get; set; } = string.Empty;
    public string CronExpression { get; set; } = string.Empty;
    public string TriggerName { get; set; } = string.Empty;
    /// <summary>
    /// Name of the class that implements the job logic within the application assembly
    /// </summary>
    public string ClassServiceName { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;
}
