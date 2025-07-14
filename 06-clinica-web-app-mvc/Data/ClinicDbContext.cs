using _06_clinica_web_app_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_clinica_web_app_mvc.Data;

public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) {}

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

}
