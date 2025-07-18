using _10_library_web_api.Models;
using _10_library_web_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_library_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController(IAuthorsRepository crudRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get() => Ok(crudRepository.GetAllWithBooks());

    [HttpGet("{id}", Name = "GetAuthor")]
    public ActionResult<Author> Get(int id)
    {
        var author = crudRepository.GetByIdWithBooks(id);
        return author is null ? NotFound() : Ok(author); 
    }

    [HttpPost]
    public ActionResult<Author> Post([FromBody] Author author)
    {
        crudRepository.Add(author);
        crudRepository.SaveChanges();
        return CreatedAtRoute("GetAuthor", new { id = author.Id} , author);
    }

    [HttpPut("{id}")]
    public ActionResult<Author> Put(int id, [FromBody] Author author)
    {
        if (id != author.Id) { return BadRequest(); }
        var updatedAuthor = crudRepository.GetById(id);
        if (updatedAuthor is null) { return NotFound(); }
        updatedAuthor.Name = author.Name;
        crudRepository.Update(updatedAuthor);
        crudRepository.SaveChanges();
        return Ok(author);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        crudRepository.DeleteById(id);
        crudRepository.SaveChanges();
        return NoContent();
    }
}