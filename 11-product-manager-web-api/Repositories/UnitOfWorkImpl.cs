using _11_product_manager_web_api.Data;
using _11_product_manager_web_api.Repositories.Interfaces;

namespace _11_product_manager_web_api.Repositories;

public class UnitOfWorkImpl(AppDbContext context) : IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; } = new CategoryRepositoryImpl(context);
    public IProductRepository ProductRepository { get; } = new ProductRepositoryImpl(context);

    public async Task<int> CommitAsync() => await context.SaveChangesAsync();
    
    public async void Dispose()
    {
        try
        {
            await CommitAsync();
            await context.DisposeAsync();
        }
        catch (Exception e)
        {
            throw; // TODO handle exception
        }
    }
}