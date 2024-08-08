using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.ViewModels;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreDbContext _context;

    public ProductRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id) ?? new Product();
    }

    public async Task<Product> AddProductAsync(ProductView productView)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = productView.Name,
            Price = productView.Price
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
}