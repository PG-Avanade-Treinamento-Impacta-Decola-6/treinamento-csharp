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
public class ProductsController(IRepository<Product> productRepository, IRepository<Category> categoryRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAsync() => Ok(await productRepository.GetAllAsync());

    [HttpGet("{id:int:min(1)}", Name = "GetProductFromRepository")]
    public async Task<ActionResult<Product>> GetAsync(int id)
    {
        var product = await productRepository.GetAsync(id);

        if (product == null) { return NotFound(); }
        
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostAsync([FromBody] ProductEditRequest request)
    {
        var newProductCategory = await categoryRepository.GetAsync(request.CategoryId);
        if (newProductCategory == null) { return BadRequest(); }
        var newProduct = new Product(request.Name, request.Description, request.Price, request.ImageUrl, request.AmountInStock, newProductCategory);
        await productRepository.AddAsync(newProduct);
        await productRepository.SaveChangesAsync();
        return CreatedAtRoute("GetProduct", new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult<Product>> PutAsync(int id, [FromBody] ProductEditRequest request)
    {
        var product = await productRepository.GetAsync(id);
        if (product == null) { return NotFound(); }
        var productCategory = await categoryRepository.GetAsync(request.CategoryId);
        if (productCategory == null) { return BadRequest(); }
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.ImageUrl = request.ImageUrl;
        product.AmountInStock = request.AmountInStock;
        product.Category = productCategory;
        productRepository.Update(product);
        await productRepository.SaveChangesAsync();
        return Ok(product);
    }
    
    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var entityFound = await productRepository.DeleteAsync(id);
        if (!entityFound) { return NotFound(); }
        var succeeded = await productRepository.SaveChangesAsync();
        if (!succeeded) { return Problem(); }
        return NoContent();
    }
}