namespace _11_product_manager_web_api.DTOs;

public class ProductCreateDto(string name, decimal price, int categoryId)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int CategoryId { get; set; } = categoryId;
}