using AgroMarketplace.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgroMarketplace.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
