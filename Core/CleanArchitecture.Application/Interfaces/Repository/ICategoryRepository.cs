using CleanArchitecture.Application.Interfaces.GenericRepository;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repository;

public interface ICategoryRepository : IReadRepository<Category>, ICreateRepository<Category>, IUpdateRepository<Category>,
    IDeleteRepository
{
    
}