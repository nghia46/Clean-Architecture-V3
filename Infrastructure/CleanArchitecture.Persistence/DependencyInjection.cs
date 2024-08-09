using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence;

public static class DependencyInjection
{
    public static void AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IMessagePublisher, MessagePublisher>();
    }
}