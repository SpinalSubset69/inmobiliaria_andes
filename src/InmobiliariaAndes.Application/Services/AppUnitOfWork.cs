using InmobiliariaAndes.Application.Contracts;
using InmobiliariaAndes.Infrastructure.Contracts;
using InmobiliariaAndes.Infrastructure.DataAccess;
using InmobiliariaAndes.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace InmobiliariaAndes.Application.Services;

public class AppUnitOfWork(
    AppDbContext dbContext,
    ILogger<QuartzRepository> quartzRepologger
    ) : IAppUnitOfWork, IDisposable
{
    private IQuartzRepository? _quartzRepository = null;
    public IQuartzRepository QuartzRepository
    {
        get
        {
            return _quartzRepository ??= new QuartzRepository(dbContext, quartzRepologger);
        }
    }

    public void Dispose(bool disposing)
    {
        if (disposing)
        {
            _quartzRepository = null;
            dbContext.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
