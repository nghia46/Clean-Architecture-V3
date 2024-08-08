using CleanArchitecture.Application;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.API.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddApplication();
    }

    public static void AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
    }

    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}