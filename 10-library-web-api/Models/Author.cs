using System.ComponentModel.DataAnnotations;

namespace _10_library_web_api.Models;

public class Author
{
    [Key]
    public  int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }

    public ICollection<Book> Books { get; init; } = new List<Book>();
}