using RentalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Reposittories
{
    public interface  IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(Guid productId);

        Task<Product> AddProductAsync (Product product);

        Task UpdateProductAsync (Product product);

        Task DeleteProductAsync (Guid productId);

        Task<bool> IsProductAvailableAsync(int productId);
    }
}
