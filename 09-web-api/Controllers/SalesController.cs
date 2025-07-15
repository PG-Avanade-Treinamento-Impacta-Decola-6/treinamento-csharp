using _09_web_api.Data;
using _09_web_api.Models;
using _09_web_api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _09_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Sale>> Get() => Ok(dbContext.Sales.Include(x => x.Product).ToList());
    
    [HttpGet("{id:int:min(1)}", Name = "GetSale")]
    public ActionResult<Sale> Get(int id)
    {
        var product = dbContext.Sales.Include(x => x.Product).AsNoTracking().FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();    
        }
        
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Sale> Post([FromBody] SaleEditRequest  request)
    {
        var newSaleProduct = dbContext.Products.FirstOrDefault(x => x.Id == request.ProductId);
        if (newSaleProduct == null)
        {
            return BadRequest();
        }
        
        var newSale = new Sale(
            newSaleProduct,
            request.Quantity
        );
        
        dbContext.Sales.Add(newSale);
        dbContext.SaveChanges();
        return CreatedAtRoute("GetSale", new { id = newSale.Id }, newSale);
    }

    [HttpPut("{id:int:min(1)}")]
    public ActionResult<Sale> Put(int id, [FromBody] SaleEditRequest request)
    {
        var sale = dbContext.Sales.Find(id);
        if (sale == null)
        {
            return NotFound();
        }
        
        var saleProduct = dbContext.Products.FirstOrDefault(x => x.Id == request.ProductId);
        if (saleProduct == null)
        {
            return BadRequest();
        }
        
        sale.Quantity = request.Quantity;
        sale.Product = saleProduct;

        dbContext.Update(sale);
        dbContext.SaveChanges();
        return Ok(sale);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(int id)
    {
        var sale = dbContext.Sales.Find(id);
        if (sale == null)
        {
            return NotFound();
        }
        dbContext.Sales.Remove(sale);
        dbContext.SaveChanges();
        return Ok();
    }
}