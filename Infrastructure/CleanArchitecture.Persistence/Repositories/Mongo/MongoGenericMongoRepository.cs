using System.Linq.Expressions;
using CleanArchitecture.Application.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CleanArchitecture.Persistence.Repositories.Mongo;

public class MongoGenericMongoRepository<T> : IMongoRepository<T>
    where T : class
{
    private readonly IMongoCollection<T> _collection;

    public MongoGenericMongoRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        var databaseName = configuration.GetSection("MongoDbSettings:DatabaseName").Value;
        var database = mongoClient.GetDatabase(databaseName);
        _collection = database.GetCollection<T>(typeof(T).Name);
    }

    public async Task<IEnumerable<T>> GetsAsync()
    {
        return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
    }

    public async Task<T> GetByPropertyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _collection.Find(predicate).FirstOrDefaultAsync();
    }

    public async Task Create(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task Update(Guid id, T entity)
    {
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }
}