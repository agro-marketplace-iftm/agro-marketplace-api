using AgroMarketplace.Api.Models;
using AgroMarketplace.Api.Models.DTOS.Request;
using AgroMarketplace.Api.Models.DTOS.Response;

namespace AgroMarketplace.Api.Services.Product
{
    public interface IProductService
    {
        ApiResponse<ProductResponseDto> CreateProductAsync(CreateProductRequestDto request);
    }
}
