using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<StoreDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        // Add AutoMapper
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
    }
}