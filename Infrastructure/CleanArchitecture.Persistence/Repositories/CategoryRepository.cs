using System.Linq.Expressions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces.Repository;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class CategoryRepository(StoreDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetsAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await context.Categories.FirstAsync(x => x.Id == id);
    }

    public async Task<Category> GetByPropertyAsync(Expression<Func<Category, bool>> predicate)
    {
        return await context.Categories.AsNoTracking().FirstOrDefaultAsync(predicate) ?? new Category();
    }

    public async Task Create(Category entity)
    {
        await context.Categories.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Category entity)
    {
        var existingCategory = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCategory == null) return;
        context.Entry(existingCategory).CurrentValues.SetValues(entity);
        context.Entry(existingCategory).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category == null) return;
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }
}