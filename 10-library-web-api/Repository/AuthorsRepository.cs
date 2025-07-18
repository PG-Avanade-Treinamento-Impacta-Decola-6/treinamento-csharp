using _10_library_web_api.Data;
using _10_library_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_library_web_api.Repository;

public class AuthorsRepository(AppDbContext dbContext) : BaseCrudRepository<Author>(dbContext)
{
    public ICollection<Author> GetAllWithBooks() => dbContext.Authors.Include(a => a.Books).ToList();
    
    public Author? GetByIdWithBooks(int id) => dbContext.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
}