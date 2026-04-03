using AgroMarketplace.Api.Models.DTOS.Request;
using AgroMarketplace.Api.Models.Entities;
using AgroMarketplace.Api.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace AgroMarketplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto request)
        {
            var response = await _productService.CreateProductAsync(request);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var response = await _productService.GetProductAsync(id);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] UpdateProductRequestDto request)
        {
            var response = await _productService.UpdateProductAsync(id, request);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (!response.Success)
            {
                return StatusCode(response.StatusCode, response);
            }

            return Ok(response);
        }
    }
}