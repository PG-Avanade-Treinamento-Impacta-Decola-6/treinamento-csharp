using _10_library_web_api.Data;
using _10_library_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_library_web_api.Repository;

public class BooksRepository(AppDbContext dbContext) : CrudRepository<Book>(dbContext), IBooksRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    public ICollection<Book> GetAllWithAuthors() => _dbContext.Books.Include(a => a.Author).ToList();
    
    public Book? GetByIdWithAuthors(int id) => _dbContext.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
}