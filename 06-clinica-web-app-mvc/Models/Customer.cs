using System.ComponentModel.DataAnnotations;

namespace _06_clinica_web_app_mvc.Models;

public class Customer()
{
    [Key]
    [Display(Name = "ID")]
    public int? Id { get; init; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "Nome")]
    public string? Name { get; set; }

    [Required]
    [Display(Name="Data de Nascimento")]
    public DateOnly BirthDate { get; set; }

    public Customer(string name, DateOnly birthDate) : this()
    {
        Name = name;
        BirthDate = birthDate;
    }
}
