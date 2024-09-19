using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<ResponseModel<ProductDto>> GetByIdAsync(Guid productId);

        Task<ResponseModel<ProductDto>> AddProductAsync(ProductDto productDto);

        Task<ResponseModel<ProductDto>> UpdateProductAsync(ProductDto productDto);

        Task<ResponseModel> DeleteProductAsync(Guid productId);

        Task<ResponseModel<bool>> IsProductAvailableAsync(int productId);
    }
}
