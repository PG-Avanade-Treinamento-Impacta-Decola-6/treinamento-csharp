using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _09_web_api.Models;

public class Category
{
    [Key]
    public int Id { get; init; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string ImageUrl { get; set; }
    
    // [JsonIgnore]
    public ICollection<Product> Products { get; init; }

    public Category(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
        Products = new List<Product>();
    }

    public Category() { }
}