using _09_web_api.Data;
using Microsoft.EntityFrameworkCore;

namespace _09_web_api.Repositories;

public class BaseRepository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await dbContext.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetAsync(int id)
        => await dbContext.Set<TEntity>().FindAsync(id);

    public async Task<TEntity> AddAsync(TEntity entity)
        => (await dbContext.Set<TEntity>().AddAsync(entity)).Entity;

    public TEntity Update(TEntity entity)
        => (dbContext.Update(entity)).Entity;

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        
        if (entity is null) { return false; }
        
        dbContext.Set<TEntity>().Remove(entity);

        return true;
    }

    public async Task<bool> SaveChangesAsync()
        => await dbContext.SaveChangesAsync() > 0;
}