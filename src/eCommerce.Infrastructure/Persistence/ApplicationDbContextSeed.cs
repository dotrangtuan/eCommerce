using eCommerce.Domain.Entities;
using eCommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.Persistence;

public class ApplicationDbContextSeed
{
    
    private readonly ApplicationDbContext _context;
    
    public ApplicationDbContextSeed(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            // Logging.Error("An error occurred while initialising the database.");
            throw;
        }
    }
    
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
            await _context.SaveChangesAsync(false);
        }
        catch (Exception e)
        {
            // Logging.Error("An error occurred while seeding the database;");
            throw;
        }
    }
    
    private async Task TrySeedAsync()
    {
        if (!_context.Categories.Any())
        {
            await _context.AddRangeAsync(GetCategories());
        }
    }

    private IEnumerable<Category> GetCategories()
    {
        return new List<Category>
        {
            new Category() {Name = "Name 1", Description = "Description 1", CreatedBy = "admin", CreatedDate = DateHelper.Now}
        };
    }
}