using _11_product_manager_web_api.Models;

namespace _11_product_manager_web_api.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ProductCount { get; set; }

    public static CategoryDto FromCategory(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name!,
            ProductCount = category.Products.Count
        };
    }
}