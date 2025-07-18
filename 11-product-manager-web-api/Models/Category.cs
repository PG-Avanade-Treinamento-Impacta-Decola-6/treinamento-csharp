using System.ComponentModel.DataAnnotations;

namespace _11_product_manager_web_api.Models;

public class Category(string name)
{
    [Key]
    public int Id { get; init; }

    [MaxLength(50)] public string? Name { get; set; } = name;

    public ICollection<Product> Products { get; init; } = new List<Product>();
}