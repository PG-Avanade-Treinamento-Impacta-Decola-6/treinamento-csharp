using System.ComponentModel.DataAnnotations;
using _08_catalogo_web_api.Core.Enums;

namespace _08_catalogo_web_api.Core.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(50)]
    public ProductType Type { get; set; }
    
    public decimal Price { get; set; }
    
    public Product(string name, ProductType type, decimal price)
    {
        Name = name;
        Type = type;
        Price = type switch
        {
            ProductType.HOME_APPLIANCES => price * 0.9m,
            ProductType.CLOTHING => price * 0.8m,
            _ => price,
        };

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name is required");
        }
        
        if (Price <= 0)
        {
            throw new ArgumentException("Price must be greater than 0");
        }
    }
}
