using AgroMarketplace.Api.Data;
using AgroMarketplace.Api.Models;
using AgroMarketplace.Api.Models.DTOS.Request;
using AgroMarketplace.Api.Models.DTOS.Response;
using AgroMarketplace.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
                ProductEntity product = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Category = request.Category,
                    ImageUrl = request.ImageUrl,
                    Stock = request.Stock,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Add(product);
                await _context.SaveChangesAsync();

                ProductResponseDto productResponse = new ProductResponseDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category,
                    ImageUrl = product.ImageUrl,
                    Stock = product.Stock,
                };

                return ApiResponse<ProductResponseDto>.SuccessResponse(
                    $"O Produto {product.Name} foi cadastrado com sucesso",
                    productResponse,
                    201
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductResponseDto>.FailureResponse(
                    $"Ocorreu um erro ao criar o produto {request.Name}: {ex.Message}"
                );
            }
        }

        public async Task<ApiResponse<IEnumerable<ProductResponseDto>>> GetAllProductsAsync()
        {
            try
            {
                List<ProductEntity> products = await _context.Products.ToListAsync();
                IEnumerable<ProductResponseDto> productDtos = products.Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Category = p.Category,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock
                });

                return ApiResponse<IEnumerable<ProductResponseDto>>.SuccessResponse(
                    "Produtos obtidos com sucesso",
                    productDtos
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ProductResponseDto>>.FailureResponse(
                    $"Ocorreu um erro ao obter os produtos: {ex.Message}"
                );
            }
        }

        public async Task<ApiResponse<ProductResponseDto>> GetProductAsync(string id)
        {
            try
            {
                // 1. Check if the provided ID is a valid GUID
                if (!Guid.TryParse(id, out Guid productId))
                {
                    return ApiResponse<ProductResponseDto>.FailureResponse(
                        "O formato do ID fornecido é inválido.",
                        400
                    );
                }

                // 2. Attempt to find the product by its ID
                ProductEntity? product = await _context.Products.FindAsync(productId);

                // 3. If the product is not found, return a 404 Not Found response
                if (product == null)
                {
                    return ApiResponse<ProductResponseDto>.FailureResponse("Produto não encontrado", 404);
                }

                return ApiResponse<ProductResponseDto>.SuccessResponse(
                    "Produto obtido com sucesso",
                    new ProductResponseDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Category = product.Category,
                        ImageUrl = product.ImageUrl,
                        Stock = product.Stock
                    }
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductResponseDto>.FailureResponse(
                    $"Ocorreu um erro ao obter o produto: {ex.Message}"
                );
            }
        }
    }
}