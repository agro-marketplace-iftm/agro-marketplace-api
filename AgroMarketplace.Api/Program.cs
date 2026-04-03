using AgroMarketplace.Api.Data;
using AgroMarketplace.Api.Data.Seeders;
using AgroMarketplace.Api.Services.Product;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), "..", ".env"));

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddControllers();

// Entity Framework Config.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Swagger Config.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services Config.
builder.Services.AddScoped<IProductService, ProductService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seed the database with initial data
using (IServiceScope scope = app.Services.CreateScope())
{
    AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DatabaseSeeder.Seed(context);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();