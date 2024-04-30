using CleanArchitecture.Application.DependencyInjection;
using CleanArchitecture.Domain.Interfaces;
using Clean_Architecture_V3.Persistence.Repositories;
using Clean_Architecture_V3.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddApplication();
    }
    public static void AddPersistenceDependencies(this IServiceCollection services)
    {
        //services.AddScoped<IProductRepository, FakeDataStore>();
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
