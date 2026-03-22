using AgroMarketplace.Api.Data;
using AgroMarketplace.Api.Models;
using AgroMarketplace.Api.Models.DTOS.Request;
using AgroMarketplace.Api.Models.DTOS.Response;
using AgroMarketplace.Api.Models.Entities;

namespace AgroMarketplace.Api.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<ProductResponseDto>> CreateProductAsync(CreateProductRequestDto request)
        {
            try
            {
                // 1. Create an Entity of request
                ProductEntity product = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Category = request.Category,
                    ImageUrl = request.ImageUrl,
                    Stock = request.Stock,
                    CreatedAt = DateTime.Now
                };

                // 2. Save on DB
                _context.Add(product);
                await _context.SaveChangesAsync();

                return new ApiResponse<ProductResponseDto>
                {
                    Success = true,
                    Message = $"O Produto {product.Name} foi cadastrado com sucesso",
                    Data = new ProductResponseDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Category = product.Category,
                        ImageUrl = product.ImageUrl,
                        Stock = product.Stock,
                    }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProductResponseDto>
                {
                    Success = false,
                    Message = $"Ocorreu um erro ao criar o produto {request.Name}: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}
