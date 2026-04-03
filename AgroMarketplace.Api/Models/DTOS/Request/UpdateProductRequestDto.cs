namespace AgroMarketplace.Api.Models.DTOS.Request;

public class UpdateProductRequestDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int Stock { get; set; }
}