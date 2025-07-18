using _11_product_manager_web_api.Data;
using _11_product_manager_web_api.DTOs;
using _11_product_manager_web_api.Models;
using _11_product_manager_web_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _11_product_manager_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(IUnitOfWork uow) : ControllerBase
{
    private readonly IUnitOfWork _uow =  uow;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        => Ok((await _uow.CategoryRepository.GetAllWithProductsAsync()).Select(CategoryDto.FromCategory));
    
    [HttpGet("{id:int}", Name = "GetCategoryByIdAsync")]
    public async Task<ActionResult<Category>> GetByIdAsync(int id)
    {
        var category = await _uow.CategoryRepository.GetByIdWithProductsAsync(id);
        await _uow.CommitAsync();
        if (category == null) { return NotFound(); }
        return Ok(CategoryWithProductsDto.FromCategory(category));
    }

    [HttpPost]
    public async Task<ActionResult<Category>> PostAsync([FromBody] CategoryCreateDto createDto)
    {
        Category newCategory = new(createDto.Name);
        await _uow.CategoryRepository.CreateAsync(newCategory);
        await _uow.CommitAsync();
        return CreatedAtRoute("GetCategoryByIdAsync", new {id = newCategory.Id}, CategoryDto.FromCategory(newCategory));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Category>> PutAsync(int id, [FromBody] CategoryCreateDto createDto)
    {
        var updatedCategory = await _uow.CategoryRepository.GetByIdWithProductsAsync(id);
        if (updatedCategory == null) { return NotFound(); }
        
        updatedCategory.Name = createDto.Name;
        
        await _uow.CategoryRepository.UpdateAsync(updatedCategory);
        await _uow.CommitAsync();
        
        return Ok(CategoryDto.FromCategory(updatedCategory));
    }
}