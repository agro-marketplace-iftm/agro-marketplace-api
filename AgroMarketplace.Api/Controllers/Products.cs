using AgroMarketplace.Api.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgroMarketplace.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            List<ProductEntity> products = new List<ProductEntity>()
            {
                new ProductEntity
                {
                   Id = Guid.NewGuid(),
                   Name = "Feijão",
                   Category = "Grãos",
                   Stock = 10,
                   Price = 100.234m,
                   CreatedAt = DateTime.Now,
                   Description = "Feijão Preto direto de Tombos",
                   ImageUrl = "https://t4.ftcdn.net/jpg/04/53/15/87/360_F_453158702_nbRkltuoNuVGznoNPDJTXDIaT7vDvnAO.jpg"
                }
            };

            return Ok(products);
        }
    }
}
