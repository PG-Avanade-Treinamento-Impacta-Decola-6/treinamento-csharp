using _06_clinica_web_app_mvc.Data;
using _06_clinica_web_app_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _06_clinica_web_app_mvc.Controllers;

public class AppointmentsController(ClinicDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        var appointments = await context.Appointments.ToListAsync();
        return View(appointments);
    }

    public IActionResult Create() => View();
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Appointment newAppointment)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        
        context.Appointments.Add(newAppointment);
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Edit(int? id) // Chamada da página de formulario
    {
        var appointment = await context.Appointments.FindAsync(id);
        
        if (appointment == null)
        {
            return NotFound();
        }
        
        return View(appointment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Appointment appointment) // Ação de edit
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }
        
        context.Appointments.Update(appointment);
        await context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        var appointment = context.Appointments.Find(id!);
        
        if (appointment == null)
        {
            return RedirectToAction("Index");
        }
        
        return View(appointment);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Appointment appointment)
    {
        context.Appointments.Remove(appointment);
        context.SaveChanges();
        
        return RedirectToAction("Index");
    }
}