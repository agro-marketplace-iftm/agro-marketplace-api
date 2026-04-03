using AgroMarketplace.Api.Models;
using AgroMarketplace.Api.Models.DTOS.Request;
using AgroMarketplace.Api.Models.DTOS.Response;

namespace AgroMarketplace.Api.Services.Product
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponseDto>> CreateProductAsync(CreateProductRequestDto request);
        Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllProductsAsync();
        Task<ApiResponse<ProductResponseDto>> GetProductAsync(string id);
        Task<ApiResponse<ProductResponseDto>> UpdateProductAsync(string id, UpdateProductRequestDto request);
    }
}
