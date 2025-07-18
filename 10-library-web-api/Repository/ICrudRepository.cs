namespace _10_library_web_api.Repository;

public interface ICrudRepository<TEntity> where TEntity : class
{
    ICollection<TEntity> GetAll();
    TEntity? GetById(int id);
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    bool DeleteById(int id);
    bool Delete(TEntity entity);
    bool SaveChanges();
}