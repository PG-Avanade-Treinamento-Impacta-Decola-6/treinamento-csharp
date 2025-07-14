using System.ComponentModel.DataAnnotations;
using _08_catalogo_web_api.Core.Entities;
using _08_catalogo_web_api.Core.Enums;
using _08_catalogo_web_api.Core.Interfaces;
using _08_catalogo_web_api.Infrastructure.Data;
using _08_catalogo_web_api.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseInMemoryDatabase("CatalogDb")
);

// Dependencies
builder.Services.AddScoped<IProductRepository, ProductRepositoryInMemImpl>();
builder.Services.AddScoped<IProductService, ProductServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Endpoint Definitions
app.MapPost(("/products"), async (ProductCreateRequest createRequest, IProductService productService) =>
{
    Product newProduct = new(createRequest.Name, createRequest.Type, createRequest.Price);
    await productService.AddAsync(newProduct);
    return Results.Created($"/products/{newProduct.Id}", newProduct);
});

app.MapGet("/products", async (IProductService productService) => Results.Ok(await productService.GetAllAsync()));

// 

app.Run();

// Entity & Context Definitions
internal abstract record ProductCreateRequest(string Name, ProductType Type,  decimal Price);
public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}