using _09_web_api.Data;
using _09_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _09_web_api.Repositories;

public class CategoryRepository(AppDbContext dbContext) : BaseRepository<Category>(dbContext)
{
    public async Task<IEnumerable<Category>> GetAllWithProductsAsync()
        => await dbContext.Categories.Include(x => x.Products).ToListAsync();
    
    public async Task<Category?> GetWithProductsAsync(int id)
        => await dbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => id ==  x.Id);
}