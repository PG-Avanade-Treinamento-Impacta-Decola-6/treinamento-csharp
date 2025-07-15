using _10_library_web_api.Models;
using _10_library_web_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_library_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(IRepository<Book> repository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get() => Ok(((BooksRepository)repository).GetAllWithAuthors());

    [HttpGet("{id}", Name = "GetBook")]
    public ActionResult<Book> Get(int id)
    {
        var book = ((BooksRepository)repository).GetByIdWithAuthors(id);
        return book is null ? NotFound() : Ok(book); 
    }

    [HttpPost]
    public ActionResult<Book> Post([FromBody] Book book)
    {
        repository.Add(book);
        repository.SaveChanges();
        return CreatedAtRoute("GetBook", new { id = book.Id} , book);
    }

    [HttpPut("{id}")]
    public ActionResult<Book> Put(int id, [FromBody] Book book)
    {
        if (id != book.Id) { return NotFound(); }
        var updatedBook = repository.GetById(id);
        if (updatedBook is null) { return NotFound(); }
        updatedBook.Title = book.Title;
        updatedBook.AuthorId = book.AuthorId;
        repository.Update(updatedBook);
        repository.SaveChanges();
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        repository.DeleteById(id);
        repository.SaveChanges();
        return NoContent();
    }
}