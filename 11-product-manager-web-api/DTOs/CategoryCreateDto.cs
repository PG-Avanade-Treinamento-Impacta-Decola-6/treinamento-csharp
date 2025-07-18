using System.ComponentModel.DataAnnotations;

namespace _11_product_manager_web_api.DTOs;

public class CategoryCreateDto(string name)
{
    public string Name { get; set; } = name;
}