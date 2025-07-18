using _10_library_web_api.Models;
using _10_library_web_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_library_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(IBooksRepository crudRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Book>> Get() => Ok(crudRepository.GetAllWithAuthors());

    [HttpGet("{id}", Name = "GetBook")]
    public ActionResult<Book> Get(int id)
    {
        var book = crudRepository.GetByIdWithAuthors(id);
        return book is null ? NotFound() : Ok(book); 
    }

    [HttpPost]
    public ActionResult<Book> Post([FromBody] Book book)
    {
        crudRepository.Add(book);
        crudRepository.SaveChanges();
        return CreatedAtRoute("GetBook", new { id = book.Id} , book);
    }

    [HttpPut("{id}")]
    public ActionResult<Book> Put(int id, [FromBody] Book book)
    {
        if (id != book.Id) { return NotFound(); }
        var updatedBook = crudRepository.GetById(id);
        if (updatedBook is null) { return NotFound(); }
        updatedBook.Title = book.Title;
        updatedBook.AuthorId = book.AuthorId;
        crudRepository.Update(updatedBook);
        crudRepository.SaveChanges();
        return Ok(book);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        crudRepository.DeleteById(id);
        crudRepository.SaveChanges();
        return NoContent();
    }
}