using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.GenericRepository;

namespace CleanArchitecture.Domain.Interfaces.Repository;

public interface IProductRepository : IReadRepository<Product>, ICreateRepository<Product>, IUpdateRepository<Product>,
    IDeleteRepository
{
}