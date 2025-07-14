using System.ComponentModel.DataAnnotations;

namespace _06_clinica_web_app_mvc.Models;

public class Appointment()
{
    [Key]
    [Display(Name="ID")]
    public int? Id { get; init; }
    
    [Required]
    [Display(Name="Cliente")]
    [MaxLength(50)]
    public string? Customer { get; set; }
    
    [Required]
    [Display(Name="Especialização do Profissional")]
    [MaxLength(50)]
    public string? FieldOfStudy { get; set; }
    
    [Required]
    [Display(Name="Profissional")]
    [MaxLength(50)]
    public string? Professional { get; set; }
    
    [Required]
    [Display(Name="Procedimento")]
    [MaxLength(50)]
    public string? Procedure { get; set; }
    
    [Required]
    [Display(Name="Horário de Agendamento")]
    public DateTime? ScheduledTime { get; set; }
    
    public Appointment(string customer, string fieldOfStudy, string professional, string procedure, DateTime scheduledTime) : this()
    {
        Customer = customer;
        FieldOfStudy = fieldOfStudy;
        Professional = professional;
        Procedure = procedure;
        ScheduledTime = scheduledTime;
    }
}