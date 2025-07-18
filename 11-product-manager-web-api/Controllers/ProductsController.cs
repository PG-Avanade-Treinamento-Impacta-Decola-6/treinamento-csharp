using _11_product_manager_web_api.Data;
using _11_product_manager_web_api.DTOs;
using _11_product_manager_web_api.Models;
using _11_product_manager_web_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _11_product_manager_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(IUnitOfWork uow) : ControllerBase
{
    private readonly IUnitOfWork _uow =  uow;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        => Ok((await _uow.ProductRepository.GetAllWithCategoryAsync()).Select(ProductDto.FromProduct));
    
    [HttpGet("{id:int}", Name = "GetProductByIdAsync")]
    public async Task<ActionResult<Product>> GetByIdAsync(int id)
    {
        var product = await _uow.ProductRepository.GetByIdWithCategoryAsync(id);
        await _uow.CommitAsync();
        if (product == null) { return NotFound(); }
        return Ok(ProductDto.FromProduct(product));
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostAsync([FromBody] ProductCreateDto createDto)
    {
        Product? newProduct = new(createDto.Name, createDto.Price, createDto.CategoryId);
        await _uow.ProductRepository.CreateAsync(newProduct);
        await _uow.CommitAsync();
        newProduct = await _uow.ProductRepository.GetByIdWithCategoryAsync(newProduct.Id);
        return CreatedAtRoute("GetProductByIdAsync", new {id = newProduct!.Id}, ProductDto.FromProduct(newProduct));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> PutAsync(int id, [FromBody] ProductCreateDto createDto)
    {
        var updatedProduct = await _uow.ProductRepository.GetByIdAsync(id);
        if (updatedProduct == null) { return NotFound(); }
        
        updatedProduct.Name = createDto.Name;
        updatedProduct.Price = createDto.Price;
        updatedProduct.CategoryId = createDto.CategoryId;
        
        await _uow.ProductRepository.UpdateAsync(updatedProduct);
        await _uow.CommitAsync();
        
        updatedProduct = await _uow.ProductRepository.GetByIdWithCategoryAsync(updatedProduct.Id);
            
        return Ok(ProductDto.FromProduct(updatedProduct!));
    }
}