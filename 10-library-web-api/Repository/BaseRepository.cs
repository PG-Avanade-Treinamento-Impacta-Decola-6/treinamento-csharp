using _10_library_web_api.Data;

namespace _10_library_web_api.Repository;

public class BaseRepository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : class
{
    public ICollection<TEntity> GetAll() => dbContext.Set<TEntity>().ToList();

    public TEntity? GetById(int id) => dbContext.Set<TEntity>().Find(id);

    public TEntity Add(TEntity entity)
    {
        dbContext.Set<TEntity>().Add(entity);
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        dbContext.Set<TEntity>().Update(entity);
        return entity;
    }

    public bool DeleteById(int id)
    {
        var entity = dbContext.Set<TEntity>().Find(id);
        if (entity is null) return false;
        return Delete(entity);
    }

    public bool Delete(TEntity entity)
    {
        dbContext.Set<TEntity>().Remove(entity);
        return true;
    }

    public bool SaveChanges() =>  dbContext.SaveChanges() > 0;
}