using _11_product_manager_web_api.Models;

namespace _11_product_manager_web_api.DTOs;

public class ProductSummaryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }

    public static ProductSummaryDto FromProduct(Product product)
    {
        return new ProductSummaryDto()
        {
            Id = product.Id,
            Name = product.Name!,
            Price = product.Price
        };
    }
}