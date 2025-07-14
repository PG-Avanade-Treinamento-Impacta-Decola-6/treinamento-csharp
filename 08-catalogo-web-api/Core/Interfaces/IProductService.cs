using _08_catalogo_web_api.Core.Entities;

namespace _08_catalogo_web_api.Core.Interfaces;

public interface IProductService
{
    Task AddAsync(Product product);
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}