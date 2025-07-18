using _10_library_web_api.Models;

namespace _10_library_web_api.Repository;

public interface IBooksRepository : ICrudRepository<Book>
{
    public ICollection<Book> GetAllWithAuthors();
    public Book? GetByIdWithAuthors(int id);
}