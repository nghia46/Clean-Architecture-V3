using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.GenericRepository;

namespace CleanArchitecture.Domain.Interfaces.Repository;

public interface ICategoryRepository : IReadRepository<Category>, ICreateRepository<Category>, IUpdateRepository<Category>,
    IDeleteRepository
{
    
}