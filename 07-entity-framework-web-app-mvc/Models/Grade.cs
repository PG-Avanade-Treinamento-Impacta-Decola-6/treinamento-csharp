using System.ComponentModel.DataAnnotations;

namespace _07_entity_framework_web_app_mvc.Models;

public class Grade
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Student> Students { get; set; } = new List<Student>();
}