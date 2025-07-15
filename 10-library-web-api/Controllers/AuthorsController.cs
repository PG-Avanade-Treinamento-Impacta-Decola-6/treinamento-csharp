using _10_library_web_api.Models;
using _10_library_web_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_library_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController(IRepository<Author> repository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get() => Ok(((AuthorsRepository)repository).GetAllWithBooks());

    [HttpGet("{id}", Name = "GetAuthor")]
    public ActionResult<Author> Get(int id)
    {
        var author = ((AuthorsRepository)repository).GetByIdWithBooks(id);
        return author is null ? NotFound() : Ok(author); 
    }

    [HttpPost]
    public ActionResult<Author> Post([FromBody] Author author)
    {
        repository.Add(author);
        repository.SaveChanges();
        return CreatedAtRoute("GetAuthor", new { id = author.Id} , author);
    }

    [HttpPut("{id}")]
    public ActionResult<Author> Put(int id, [FromBody] Author author)
    {
        if (id != author.Id) { return BadRequest(); }
        var updatedAuthor = repository.GetById(id);
        if (updatedAuthor is null) { return NotFound(); }
        updatedAuthor.Name = author.Name;
        repository.Update(updatedAuthor);
        repository.SaveChanges();
        return Ok(author);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        repository.DeleteById(id);
        repository.SaveChanges();
        return NoContent();
    }
}