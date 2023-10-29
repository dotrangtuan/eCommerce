using eCommerce.Application.Infrastructure;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Persistence;

namespace eCommerce.Infrastructure.Repositories;

public class ProductWriteOnlyRepository : BaseWriteOnlyRepository<Product, ApplicationDbContext> ,IProductWriteOnlyRepository
{
    public ProductWriteOnlyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}