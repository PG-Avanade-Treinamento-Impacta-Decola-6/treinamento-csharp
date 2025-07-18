using _11_product_manager_web_api.Models;

namespace _11_product_manager_web_api.DTOs;

public class ProductDto : ProductSummaryDto
{
    public required CategoryDto Category { get; set; }

    public new static ProductDto FromProduct(Product product)
    {
        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name!,
            Price = product.Price,
            Category = CategoryDto.FromCategory(product.Category!)
        };
    }
}