using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Entities;
using System;

namespace RentalManagementSystem.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseModel<ProductDto>> AddProductAsync(ProductDto productDto)
        {
            try
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    RentalPrice = productDto.RentalPrice,
                    StockQuantity = productDto.StockQuantity,
                    Available = productDto.Available,
                };

                var addedProduct = await _productRepository.AddProductAsync(product);

                if (addedProduct == null)
                {
                    return new ResponseModel<ProductDto>
                    {
                        IsSuccessful = false,
                        Message = "Failed to add product"
                    };
                }

                productDto.Id = addedProduct.Id;
                return new ResponseModel<ProductDto>
                {
                    IsSuccessful = true,
                    Message = "Product added successfully",
                    Data = productDto
                };
            }
            catch (Exception ex)
            {
                return ResponseModel<ProductDto>.Failure($"Error occurred while adding product: {ex.Message}");
            }
        }

        public async Task<ResponseModel> DeleteProductAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(productId);

                if (product == null)
                {
                    return new ResponseModel<ProductDto>
                    {
                        IsSuccessful = false,
                        Message = $"Product with Id {productId} not found"
                    };
                }

                await _productRepository.DeleteProductAsync(productId);
                return new ResponseModel<ProductDto>
                {
                    IsSuccessful = true,
                    Message = $"Deleted product with Id {productId} successfully"
                };
            }
            catch (Exception ex)
            {
                return ResponseModel.Failure($"Error occurred while deleting product: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                // Handle the error by either throwing or logging it
                throw new Exception($"Error occurred while fetching products: {ex.Message}");
            }
        }

        public async Task<ResponseModel<ProductDto>> GetByIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(productId);
                if (product == null)
                {
                    return new ResponseModel<ProductDto>
                    {
                        IsSuccessful = false,
                        Message = $"Product with {productId} not found"
                    };
                }

                var productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    RentalPrice = product.RentalPrice,
                    StockQuantity = product.StockQuantity,
                };

                return new ResponseModel<ProductDto>
                {
                    IsSuccessful = true,
                    Message = $"Product with {productId} retrieved successfully",
                    Data = productDto
                };
            }
            catch (Exception ex)
            {
                return ResponseModel<ProductDto>.Failure($"Error occurred while retrieving product: {ex.Message}");
            }
        }

        public async Task<ResponseModel<bool>> IsProductAvailableAsync(int productId)
        {
            try
            {
                var isAvailable = await _productRepository.IsProductAvailableAsync(productId);

                if (!isAvailable)
                {
                    return new ResponseModel<bool>
                    {
                        IsSuccessful = false,
                        Message = "Product is out of stock"
                    };
                }

                return new ResponseModel<bool>
                {
                    IsSuccessful = true,
                    Message = "Product is available"
                };
            }
            catch (Exception ex)
            {
                return ResponseModel<bool>.Failure($"Error occurred while checking product availability: {ex.Message}");
            }
        }

        public async Task<ResponseModel<ProductDto>> UpdateProductAsync(ProductDto productDto)
        {
            try
            {
                var existingProduct = await _productRepository.GetProductByIdAsync(productDto.Id);

                if (existingProduct == null)
                {
                    return new ResponseModel<ProductDto>
                    {
                        IsSuccessful = false,
                        Message = "Product not found"
                    };
                }

                existingProduct.Name = productDto.Name;
                existingProduct.Description = productDto.Description;
                existingProduct.RentalPrice = productDto.RentalPrice;
                existingProduct.StockQuantity = productDto.StockQuantity;
                existingProduct.Available = productDto.Available;

                await _productRepository.UpdateProductAsync(existingProduct);

                var updatedProductDto = new ProductDto
                {
                    Id = existingProduct.Id,
                    Name = existingProduct.Name,
                    Description = existingProduct.Description,
                    RentalPrice = existingProduct.RentalPrice,
                    StockQuantity = existingProduct.StockQuantity,
                    Available = existingProduct.Available
                };

                return new ResponseModel<ProductDto>
                {
                    IsSuccessful = true,
                    Message = "Product updated successfully",
                    Data = updatedProductDto
                };
            }
            catch (Exception ex)
            {
                return ResponseModel<ProductDto>.Failure($"Error occurred while updating product: {ex.Message}");
            }
        }
    }
}
