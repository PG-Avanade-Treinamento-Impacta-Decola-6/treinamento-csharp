using _11_product_manager_web_api.Data;
using _11_product_manager_web_api.Models;
using _11_product_manager_web_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _11_product_manager_web_api.Repositories;

public class ProductRepositoryImpl(AppDbContext dbContext) : CrudRepositoryImpl<Product>(dbContext), IProductRepository
{
    public async Task<ICollection<Product>> GetAllWithCategoryAsync()
        => await Context.Products.AsNoTracking().Include(x => x.Category).ToListAsync();

    public async Task<Product?> GetByIdWithCategoryAsync(int id)
        => await Context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
}