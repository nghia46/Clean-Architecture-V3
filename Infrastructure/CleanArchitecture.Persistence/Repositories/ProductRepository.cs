using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ViewModels;
using Clean_Architecture_V3.Infrastructure.Model;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_V3.Persistence.Repositories
{
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
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productView.Name,
                Price = productView.Price,         
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
