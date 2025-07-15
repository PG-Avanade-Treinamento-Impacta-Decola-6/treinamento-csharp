using _09_web_api.Data;
using _09_web_api.Models;
using _09_web_api.Repositories;
using _09_web_api.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _09_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(CategoryRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAsync() => Ok(await repository.GetAllWithProductsAsync());
    
    [HttpGet("{id:int:min(1)}", Name = "GetCategory")]
    public async Task<ActionResult<Category>> GetAsync(int id)
    {
        var category = await repository.GetWithProductsAsync(id);
        if (category == null) { return NotFound(); }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> PostAsync([FromBody] CategoryEditRequest  request)
    {
        var newCategory = new Category(request.Name, request.ImageUrl);
        await repository.AddAsync(newCategory);
        await repository.SaveChangesAsync();
        return CreatedAtRoute("GetCategory", new { id = newCategory.Id }, newCategory);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult<Category>> PutAsync(int id, [FromBody] CategoryEditRequest request)
    {
        var category = await repository.GetAsync(id);
        if (category == null) { return NotFound(); }
        category.Name = request.Name;
        category.ImageUrl = request.ImageUrl;
        repository.Update(category);
        await repository.SaveChangesAsync();
        return Ok(category);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var entityFound = await repository.DeleteAsync(id);
        if (!entityFound) { return NotFound(); }
        var succeeded = await repository.SaveChangesAsync();
        if (!succeeded) { return Problem(); }
        return NoContent();
    }
}