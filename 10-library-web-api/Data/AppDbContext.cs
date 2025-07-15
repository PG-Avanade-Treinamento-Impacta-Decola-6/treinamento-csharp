using _10_library_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_library_web_api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}