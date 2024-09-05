using System.Linq.Expressions;
using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class ProductRepository(StoreDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await context.Products.FirstAsync(x => x.Id == id);
    }

    public async Task<Product> GetByPropertyAsync(Expression<Func<Product, bool>> predicate)
    {
        return await context.Products.AsNoTracking().FirstOrDefaultAsync(predicate) ?? new Product();
    }

    public async Task Create(Product entity)
    {
        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Product entity)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (existingProduct == null) return;
        context.Entry(existingProduct).CurrentValues.SetValues(entity);
        context.Entry(existingProduct).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) return;
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}