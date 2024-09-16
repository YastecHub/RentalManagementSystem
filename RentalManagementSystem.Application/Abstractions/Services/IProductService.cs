using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetByIdAsync(int productId);

        Task AddProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task DeleteProductAsync(int productId);

        Task<bool> IsProductAvailableAsync(int productId);
    }
}
