using InmobiliariaAndes.Infrastructure.Contracts;

namespace InmobiliariaAndes.Application.Contracts;

public interface IAppUnitOfWork : IDisposable
{
    public IQuartzRepository QuartzRepository { get; }
}
