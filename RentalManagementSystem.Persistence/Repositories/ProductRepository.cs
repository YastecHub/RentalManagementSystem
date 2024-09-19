using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Entities;
using RentalManagementSystem.Persistence.Context;

namespace RentalManagementSystem.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _applicationDbContext.Products.AddAsync(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            var product = await _applicationDbContext.Products
                          .FindAsync(productId);
            if (product != null) 
            {
                _applicationDbContext.Products.Remove(product);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _applicationDbContext.Products.FindAsync(productId);
        }

        public async Task<bool> IsProductAvailableAsync(int productId)
        {
            var product = await _applicationDbContext.Products.FindAsync(productId);
            return product?.Available ?? false;
        }

        public async Task UpdateProductAsync(Product product)
        {
            _applicationDbContext.Products.Update(product);
           await _applicationDbContext.SaveChangesAsync();
        }
    }
}
