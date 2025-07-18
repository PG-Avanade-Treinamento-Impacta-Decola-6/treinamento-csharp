using _11_product_manager_web_api.Data;
using _11_product_manager_web_api.Models;
using _11_product_manager_web_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _11_product_manager_web_api.Repositories;

public class CategoryRepositoryImpl(AppDbContext dbContext) : CrudRepositoryImpl<Category>(dbContext), ICategoryRepository
{
    public async Task<ICollection<Category>> GetAllWithProductsAsync()
        => await Context.Categories.AsNoTracking().Include(x => x.Products).ToListAsync();

    public async Task<Category?> GetByIdWithProductsAsync(int id) 
        => await Context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
}