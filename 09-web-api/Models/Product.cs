using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _09_web_api.Models;

public class Product
{
    [Key]
    public int  Id { get; init; }

    public DateTime CreatedAt { get; init; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string ImageUrl { get; set; }
    
    [Required]
    public float AmountInStock { get; set; }
    
    [Required]
    [JsonIgnore]
    public Category Category { get; set; }
    
    public string CategoryName => Category.Name;
    
    public Product(string name, string description, decimal price, string imageUrl, float amountInStock, Category category)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        AmountInStock = amountInStock;
        Category = category;
        CreatedAt = DateTime.Now;
    }

    public Product() { }
}