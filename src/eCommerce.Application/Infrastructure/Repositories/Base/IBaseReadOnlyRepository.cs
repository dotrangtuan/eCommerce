using System.Linq.Expressions;
using eCommerce.Application.Infrastructure.Persistence;
using eCommerce.Domain.Common;

namespace eCommerce.Application.Infrastructure;

public interface IBaseReadOnlyRepository<TEntity, TDbContext> 
    where TEntity : BaseEntity
    where TDbContext : IApplicationDbContext
{
    
    
    IQueryable<TEntity> FindAll(bool trackChanges = false);
    IQueryable<TEntity> FindAll(bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties);
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false);
    IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false,
        params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);
}