using _11_product_manager_web_api.Models;

namespace _11_product_manager_web_api.DTOs;

public class CategoryWithProductsDto : CategoryDto
{
    public ICollection<ProductSummaryDto> Products { get; set; } = new List<ProductSummaryDto>();
    public new int ProductCount => Products.Count;

    public new static CategoryWithProductsDto FromCategory(Category category)
    {
        return new CategoryWithProductsDto
        {
            Id = category.Id,
            Name = category.Name!,
            Products =  category.Products.Select(ProductSummaryDto.FromProduct).ToList()
        };
    }
}