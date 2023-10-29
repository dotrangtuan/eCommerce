using System.Reflection;
using eCommerce.Application.Infrastructure.Persistence;
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    #region [CONSTRUCTOR]
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    #endregion
    
    #region [DbSet]
    
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    #endregion

    #region [Override]
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    #endregion

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await this.SaveChangesAsync(cancellationToken);
    }
}