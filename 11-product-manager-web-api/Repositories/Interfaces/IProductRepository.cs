using _11_product_manager_web_api.Models;

namespace _11_product_manager_web_api.Repositories.Interfaces;

public interface IProductRepository : ICrudRepository<Product>
{
    public Task<ICollection<Product>> GetAllWithCategoryAsync();
    public Task<Product?> GetByIdWithCategoryAsync(int id);
}