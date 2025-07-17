using System;
using InmobiliariaAndes.Domain.Entities;

namespace InmobiliariaAndes.Infrastructure.Contracts;

public interface IQuartzRepository
{
    Task<IEnumerable<QuartzConfiguration>> GetAllQuartzConfigurationsAsync();
    Task UpdateQuartzConfigurationAsync(QuartzConfiguration config, long id);
}
