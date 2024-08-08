using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ViewModels;

namespace CleanArchitecture.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(Guid id);
    Task<Product> AddProductAsync(ProductView product);
}