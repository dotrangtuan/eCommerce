using eCommerce.Application.Infrastructure.Persistence;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Infrastructure;

public interface IProductWriteOnlyRepository : IBaseWriteOnlyRepository<Product, IApplicationDbContext>
{
    
}