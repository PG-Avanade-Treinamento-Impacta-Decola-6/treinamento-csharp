using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _11_product_manager_web_api.Models;

public class Product(string? name, decimal price, int categoryId)
{
    [Key]
    public int Id { get; init; }
    [MaxLength(50)]
    public string? Name { get; set; } = name;

    public decimal Price { get; set; } = price;

    public int CategoryId { get; set; } = categoryId;

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
}