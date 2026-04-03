using AgroMarketplace.Api.Constants;
using AgroMarketplace.Api.Models.Entities;

namespace AgroMarketplace.Api.Data.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(
                // --- GRAINS (Grãos) ---
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Saca de Milho (60kg)",
                    Description = "Milho em grão tipo 1, ideal para alimentação animal e produção de ração.",
                    Price = 85.50m,
                    Category = CategoryNames.Grains,
                    ImageUrl = "https://images.unsplash.com/photo-1551754655-cd27e38d2076",
                    Stock = 100,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Saca de Soja (60kg)",
                    Description = "Soja padrão exportação, com alto teor de proteína.",
                    Price = 135.00m,
                    Category = CategoryNames.Grains,
                    ImageUrl = "https://images.unsplash.com/photo-1596431940986-e89c6d3d4b65",
                    Stock = 50,
                    CreatedAt = DateTime.UtcNow
                },

                // --- PRODUCE (Hortifruti) ---
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Banana Nanica Orgânica (1kg)",
                    Description = "Banana nanica cultivada sem agrotóxicos pelo Grupo Guandu.",
                    Price = 12.02m,
                    Category = CategoryNames.Produce,
                    ImageUrl = "https://images.unsplash.com/photo-1603833665858-e61d17a86224",
                    Stock = 30,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Morango Orgânico Congelado (250g)",
                    Description = "Morangos orgânicos selecionados e congelados.",
                    Price = 18.97m,
                    Category = CategoryNames.Produce,
                    ImageUrl = "https://images.unsplash.com/photo-1464965911861-746a04b4bca6",
                    Stock = 80,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Tomates Orgânicos Sítio Boa Vista (1kg)",
                    Description = "Tomates frescos da zona rural norte.",
                    Price = 8.00m,
                    Category = CategoryNames.Produce,
                    ImageUrl = "https://images.unsplash.com/photo-1592924357228-91a4daadcfea",
                    Stock = 120,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Alface Crespa Horta Verde Vida (un)",
                    Description = "Alface crespa fresquinha colhida no dia.",
                    Price = 3.50m,
                    Category = CategoryNames.Produce,
                    ImageUrl = "https://images.unsplash.com/photo-1622206151226-18ca2c9ab4a1",
                    Stock = 50,
                    CreatedAt = DateTime.UtcNow
                },

                // --- DAIRY (Laticínios e Derivados) ---
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Queijo Minas Artesanal (Peça)",
                    Description = "Queijo meia cura artesanal da Fazenda São José.",
                    Price = 45.00m,
                    Category = CategoryNames.Dairy,
                    ImageUrl = "https://images.unsplash.com/photo-1486297678162-eb2a19b0a32d",
                    Stock = 20,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Ovos Caipira Chácara Pôr do Sol (Dúzia)",
                    Description = "Ovos caipiras frescos de galinhas criadas soltas.",
                    Price = 18.00m,
                    Category = CategoryNames.Dairy,
                    ImageUrl = "https://images.unsplash.com/photo-1506976785307-8732e854ad03",
                    Stock = 60,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Leite Fresco Fazenda Leiteira (1L)",
                    Description = "Leite integral fresco pasteurizado.",
                    Price = 7.00m,
                    Category = CategoryNames.Dairy,
                    ImageUrl = "https://images.unsplash.com/photo-1550583724-b2692b85b150",
                    Stock = 40,
                    CreatedAt = DateTime.UtcNow
                },

                // --- ARTISANAL (Artesanais) ---
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Mel Puro Orgânico Silvestre (500g)",
                    Description = "Mel silvestre puro colhido na região Vale das Flores.",
                    Price = 35.00m, // Ajustado conforme a segunda imagem
                    Category = CategoryNames.Artisanal,
                    ImageUrl = "https://images.unsplash.com/photo-1587049352847-4d4b1263eb70",
                    Stock = 15,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Geleia de Goiaba Doces da Vovó Maria (300g)",
                    Description = "Geleia artesanal de goiaba sem conservantes.",
                    Price = 22.00m,
                    Category = CategoryNames.Artisanal,
                    ImageUrl = "https://images.unsplash.com/photo-1589134762145-21d3f272a8c6",
                    Stock = 25,
                    CreatedAt = DateTime.UtcNow
                },

                // --- PLANTS (Mudas) ---
                new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Muda Mini Cacto Decorativo (1un)",
                    Description = "Cactos ornamentais para ambientes internos.",
                    Price = 7.50m,
                    Category = CategoryNames.Plants,
                    ImageUrl = "https://images.unsplash.com/photo-1459411552884-841db9b3cc2a",
                    Stock = 100,
                    CreatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }
    }
}
