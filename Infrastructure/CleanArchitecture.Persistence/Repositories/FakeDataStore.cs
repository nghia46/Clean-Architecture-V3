using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ViewModels;
using CleanArchitecture.Domain.Interfaces;

namespace Clean_Architecture_V3.Persistence.Repositories;
public class FakeDataStore : IProductRepository
{
    private static List<Product>? _products;
    public FakeDataStore()
    {
        _products = new List<Product>
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1" },
                new() { Id = Guid.NewGuid(), Name = "Product 2" },
                new() { Id = Guid.NewGuid(), Name = "Product 3" },
                new() { Id = Guid.NewGuid(), Name = "Product 4" },
                new() { Id = Guid.NewGuid(), Name = "Product 5" }
            };
    }
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await Task.FromResult(_products) ?? [];
    }
    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        return await Task.FromResult(_products?.Single(p => p.Id == id)) ?? new Product();
    }

    public Task<Product> AddProductAsync(ProductView product)
    {
        throw new NotImplementedException();
    }
}