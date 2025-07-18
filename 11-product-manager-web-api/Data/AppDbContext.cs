using _11_product_manager_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _11_product_manager_web_api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category>  Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}