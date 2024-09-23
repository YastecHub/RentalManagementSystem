using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<ResponseModel<ProductDto>> GetByIdAsync(Guid productId);

        Task<ResponseModel<CreateProductDto>> AddProductAsync(CreateProductDto createProductDto);

        Task<ResponseModel<UpdateProductDto>> UpdateProductAsync(UpdateProductDto updateProductDto);

        Task<ResponseModel> DeleteProductAsync(Guid productId);

        Task<ResponseModel<bool>> IsProductAvailableAsync(int productId);
    }
}
