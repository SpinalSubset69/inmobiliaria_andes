using InmobiliariaAndes.Domain.Entities;
using InmobiliariaAndes.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InmobiliariaAndes.Infrastructure.DataAccess.Repositories;

public class QuartzRepository(
    AppDbContext context,
    ILogger<QuartzRepository> logger) : IQuartzRepository
{
    private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<IEnumerable<QuartzConfiguration>> GetAllQuartzConfigurationsAsync()
    {
        try
        {
            return await _context.QuartzConfigurations
            .Where(x => x.IsEnabled)
            .AsNoTracking()
            .ToListAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while retrieving Quartz configurations.");
            throw; // No need to send stack trace, just rethrow the exception
        }
    }

    public async Task UpdateQuartzConfigurationAsync(QuartzConfiguration config, long id)
    {
        try
        {
            // Get the existing configuration by id and update it
            var existingConfig = _context.QuartzConfigurations.Find(id) ?? throw new KeyNotFoundException($"QuartzConfiguration with id {id} not found.");

            existingConfig.CronExpression = config.CronExpression;
            existingConfig.JobName = config.JobName;
            existingConfig.JobGroup = config.JobGroup;
            existingConfig.Description = config.Description;
            existingConfig.IsEnabled = config.IsEnabled;

            _context.QuartzConfigurations.Update(existingConfig);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while updating the Quartz configuration.");
            throw; // No need to send stack trace, just rethrow the exception
        }
    }
}