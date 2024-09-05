using CleanArchitecture.Application.Interfaces.GenericRepository;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repository;

public interface IProductRepository : IReadRepository<Product>, ICreateRepository<Product>, IUpdateRepository<Product>,
    IDeleteRepository
{
}