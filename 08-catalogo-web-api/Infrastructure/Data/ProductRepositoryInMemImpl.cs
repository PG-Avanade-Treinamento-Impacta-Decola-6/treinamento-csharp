using _08_catalogo_web_api.Core.Entities;
using _08_catalogo_web_api.Core.Interfaces;

namespace _08_catalogo_web_api.Infrastructure.Data;

public class ProductRepositoryInMemImpl(CatalogDbContext dbContext) :  IProductRepository
{
    public Task AddAsync(Product product)
    {
        dbContext.Add(product);
        return dbContext.SaveChangesAsync();
    }

    public Task<ICollection<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}