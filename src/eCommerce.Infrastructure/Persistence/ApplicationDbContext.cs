using System.Reflection;
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    #region [DbSet]
    
    public DbSet<User> Users { get; set; }
    
    #endregion

    #region [Override]
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    #endregion
}