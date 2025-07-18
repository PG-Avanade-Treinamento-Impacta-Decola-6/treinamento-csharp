using _11_product_manager_web_api.Data;
using _11_product_manager_web_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _11_product_manager_web_api.Repositories;

public class CrudRepositoryImpl<T>(AppDbContext dbContext) : ICrudRepository<T> where T : class
{
    protected readonly AppDbContext Context = dbContext;

    public async Task<ICollection<T>> GetAllAsync()
        => await Context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) 
        => await Context.Set<T>().FindAsync(id);

    public async Task<T> CreateAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}