using eCommerce.Application.Infrastructure.Persistence;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Infrastructure;

public interface IProductReadOnlyRepository : IBaseReadOnlyRepository<Product, IApplicationDbContext>
{
    Task<IEnumerable<Product>> GetProductPagingAsync(int pageIndex, int pageSize,
        CancellationToken cancellationToken = default);
}