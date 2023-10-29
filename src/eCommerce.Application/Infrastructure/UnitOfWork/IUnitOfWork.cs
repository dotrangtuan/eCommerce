namespace eCommerce.Application.Infrastructure;

//unit of work pattern
public interface IUnitOfWork : IDisposable
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}