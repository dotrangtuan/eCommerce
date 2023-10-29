using eCommerce.Application.Infrastructure.Persistence;
using eCommerce.Infrastructure.Persistence;
using eCommerce.Shared.CoreSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(CoreSetting.ConnectionStrings["Sql"])
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
        );
        
        services.AddScoped<ApplicationDbContextSeed>();

        return services;
    }
}