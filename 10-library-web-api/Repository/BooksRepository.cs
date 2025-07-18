using _10_library_web_api.Data;
using _10_library_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace _10_library_web_api.Repository;

public class BooksRepository(AppDbContext dbContext) : BaseCrudRepository<Book>(dbContext)
{
    public ICollection<Book> GetAllWithAuthors() => dbContext.Books.Include(a => a.Author).ToList();
    
    public Book? GetByIdWithAuthors(int id) => dbContext.Books.Include(x => x.Author).FirstOrDefault(x => x.Id == id);
}