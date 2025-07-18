namespace _11_product_manager_web_api.Repositories.Interfaces;

public interface ICrudRepository<T> where T : class
{
    Task<ICollection<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
}