using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _10_library_web_api.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }
    
    [Required]
    [JsonIgnore]
    public int AuthorId { get; set; }
    
    public Author? Author { get; set; }
}