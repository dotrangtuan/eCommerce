using eCommerce.Application.Infrastructure;
using eCommerce.Domain.Common;
using eCommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class BaseWriteOnlyRepository<TEntity,TDbContext> : IBaseWriteOnlyRepository<TEntity, TDbContext>
    where TEntity : BaseEntity
    where TDbContext : ApplicationDbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;
    
    public BaseWriteOnlyRepository(
        TDbContext dbContext)
    {
        _dbContext = dbContext;
        
        _dbSet = dbContext.Set<TEntity>();

    }
    
    public IUnitOfWork UnitOfWork => _dbContext;

    #region [INSERTS]
    
    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync<TEntity>(entity, cancellationToken);
        
        return entity;
    }

    public async Task<IList<TEntity>> InsertAsync(IList<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddRangeAsync(entities, cancellationToken);
        
        return entities;
    }
    

    #endregion

    #region [UPDATE]
    
    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Update(entity);
        return entity;
    }
    
    #endregion

    #region [DELETE]

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Remove(entity);
    }
    
    public async Task DeleteAsync(IList<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.RemoveRange(entities);
    }


    #endregion
    
    
}