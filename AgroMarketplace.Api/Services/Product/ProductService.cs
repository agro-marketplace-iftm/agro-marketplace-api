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

                return new ApiResponse<IEnumerable<ProductResponseDto>>
                {
                    Success = true,
                    Message = "Produtos obtidos com sucesso",
                    Data = productDtos
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ProductResponseDto>>
                {
                    Success = false,
                    Message = $"Ocorreu um erro ao obter os produtos: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ApiResponse<ProductResponseDto>> GetProductAsync(string id)
        {
            try
            {
                ProductEntity? product = await _context.Products.FindAsync(Guid.Parse(id));
                if (product == null)
                {
                    return new ApiResponse<ProductResponseDto>
                    {
                        Success = false,
                        Message = "Produto não encontrado",
                        Data = null
                    };
                }

                return new ApiResponse<ProductResponseDto>
                {
                    Success = true,
                    Message = "Produto obtido com sucesso",
                    Data = new ProductResponseDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Category = product.Category,
                        ImageUrl = product.ImageUrl,
                        Stock = product.Stock
                    }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProductResponseDto>
                {
                    Success = false,
                    Message = $"Ocorreu um erro ao obter o produto: {ex.Message}",
                    Data = null
                };
            }
        }
    }
}
