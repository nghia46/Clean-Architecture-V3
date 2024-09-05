using CleanArchitecture.Application.Interfaces.GenericRepository;

namespace CleanArchitecture.Application.Interfaces.Repository;

public interface IMongoRepository<T> : IReadRepository<T>, ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository
    where T : class
{
    
}