using CleanArchitecture.Domain.Interfaces.AMQP;
using CleanArchitecture.Domain.Interfaces.Repository;
using CleanArchitecture.Persistence.AMQP;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence;

public static class DependencyInjection
{
    public static void AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMessagePublisher, MessagePublisher>();
    }
}