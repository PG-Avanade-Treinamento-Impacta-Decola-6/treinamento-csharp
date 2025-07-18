using _11_product_manager_web_api.Models;

namespace _11_product_manager_web_api.Repositories.Interfaces;

public interface ICategoryRepository : ICrudRepository<Category>
{
    public Task<ICollection<Category>> GetAllWithProductsAsync();
    public Task<Category?> GetByIdWithProductsAsync(int id);
}