using _08_catalogo_web_api.Core.Entities;
using _08_catalogo_web_api.Core.Interfaces;

namespace _08_catalogo_web_api.Infrastructure.Services;

public class ProductServiceImpl(IProductRepository productRepository) : IProductService
{
    public Task AddAsync(Product product)
    {
        return productRepository.AddAsync(product);
    }

    public Task<ICollection<Product>> GetAllAsync()
    {
        return productRepository.GetAllAsync();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        return productRepository.GetByIdAsync(id);
    }

    public Task UpdateAsync(Product product)
    {
        return productRepository.UpdateAsync(product);
    }

    public Task DeleteAsync(int id)
    {
        return productRepository.DeleteAsync(id);
    }
}