using CleanArchitecture.Application.Interfaces.AMQP;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.AMQP;
using CleanArchitecture.Persistence.Repositories;
using CleanArchitecture.Persistence.Repositories.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CleanArchitecture.Persistence;

public static class DependencyInjection
{
    public static void AddPersistenceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMessagePublisher, MessagePublisher>();

        #region MongoDB

        services.AddSingleton<IMongoClient>(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var connectionString = config.GetConnectionString("MongoDb");
            return new MongoClient(connectionString);
        });
        
        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoGenericMongoRepository<>));
        #endregion
        
    }
}