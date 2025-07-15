namespace _09_web_api.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    TEntity Update(TEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> SaveChangesAsync();
}