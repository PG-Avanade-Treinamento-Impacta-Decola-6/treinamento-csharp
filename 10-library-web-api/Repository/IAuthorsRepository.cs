using _10_library_web_api.Models;

namespace _10_library_web_api.Repository;

public interface IAuthorsRepository : ICrudRepository<Author>
{
    ICollection<Author> GetAllWithBooks();
    Author? GetByIdWithBooks(int id);
}