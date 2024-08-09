using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.GenericRepository;

namespace CleanArchitecture.Domain.Interfaces;

public interface IProductRepository : IReadRepository<Product>, ICreateRepository<Product>, IUpdateRepository<Product>, IDeleteRepository
{
    
}