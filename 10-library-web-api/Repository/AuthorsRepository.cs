using _10_library_web_api.Data;
using _10_library_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_library_web_api.Repository;

public class AuthorsRepository(AppDbContext dbContext) : CrudRepository<Author>(dbContext), IAuthorsRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    public ICollection<Author> GetAllWithBooks() => _dbContext.Authors.Include(a => a.Books).ToList();
    
    public Author? GetByIdWithBooks(int id) => _dbContext.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
}