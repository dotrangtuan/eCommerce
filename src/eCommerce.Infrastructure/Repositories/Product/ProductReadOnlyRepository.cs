using eCommerce.Application.Infrastructure;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Repositories;

public class ProductReadOnlyRepository : BaseReadOnlyRepository<Product, ApplicationDbContext>, IProductReadOnlyRepository
{
    public ProductReadOnlyRepository(ApplicationDbContext dbContext, IServiceProvider provider) : base(dbContext, provider)
    {
    }

    public async Task<IEnumerable<Product>> GetProductPagingAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Products
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return result;
    }
}