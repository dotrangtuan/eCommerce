using eCommerce.Application.Infrastructure;

namespace eCommerce.Application.Infrastructure;

public interface IBaseWriteOnlyRepository<TEntity, TDbContext>
{
    IUnitOfWork UnitOfWork { get; }
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IList<TEntity>> InsertAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);
}