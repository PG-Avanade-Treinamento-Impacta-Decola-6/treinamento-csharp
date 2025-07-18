namespace _11_product_manager_web_api.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    
    Task<int> CommitAsync();
}