using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Application.Services;

namespace RentalManagementSystem.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var response = await _productService.GetByIdAsync(id);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _productService.AddProductAsync(createProductDto);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtAction(nameof(GetProductById),
                new { id = response.Data.Id },
                response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid Id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (Id != updateProductDto.Id)
            {
                return BadRequest("Product ID mismatch");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.UpdateProductAsync(updateProductDto);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Message);
        }

        [HttpGet("IsAvailable/{productId}")]
        public  async Task<IActionResult> IsProductAvailable(int productId)
        {
            var response = await _productService.IsProductAvailableAsync(productId);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}
