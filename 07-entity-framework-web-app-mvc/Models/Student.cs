using System.ComponentModel.DataAnnotations;

namespace _07_entity_framework_web_app_mvc.Models;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public int GradeId { get; set; }
    public Grade? Grade { get; set; }
}