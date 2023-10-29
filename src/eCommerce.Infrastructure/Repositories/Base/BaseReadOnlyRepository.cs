using System.Linq.Expressions;
using eCommerce.Application.Infrastructure;
using eCommerce.Application.Infrastructure.Persistence;
using eCommerce.Domain.Common;
using eCommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class BaseReadOnlyRepository<TEntity, TDbContext> : IBaseReadOnlyRepository<TEntity, TDbContext>
    where TEntity :  BaseEntity
    where TDbContext : ApplicationDbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly IServiceProvider _provider;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseReadOnlyRepository(
        TDbContext dbContext,
        IServiceProvider provider)
    {
        _dbContext = dbContext;
        _provider = provider;
        _dbSet = dbContext.Set<TEntity>();

    }
    
    public IQueryable<TEntity> FindAll(bool trackChanges = false)
    {
        return !trackChanges ? _dbSet.AsNoTracking() : _dbSet;
    }

    public IQueryable<TEntity> FindAll(bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var queryable = FindAll(trackChanges);
        queryable = includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        return queryable;
    }

    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false)
    {
        return !trackChanges ? _dbSet.Where(expression).AsNoTracking() : _dbSet.Where(expression);
    }
    
    public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var queryable = FindByCondition(expression, trackChanges);
        queryable = includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
        return queryable;
    }
    
    public async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await FindByCondition(x => x.Id.Equals(id))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(object id,  CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties)
    {
         return await FindByCondition(x => x.Id.Equals(id), trackChanges: false, includeProperties)
            .FirstOrDefaultAsync(cancellationToken);
    }
}