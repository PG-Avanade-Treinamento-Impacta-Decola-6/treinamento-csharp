using System.Runtime.InteropServices.JavaScript;
using _06_clinica_web_app_mvc.Data;
using _06_clinica_web_app_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _06_clinica_web_app_mvc.Controllers;

public class CustomersController(ClinicDbContext context) : Controller
{
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Customer newCustomer)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        
        context.Customers.Add(newCustomer);
        await context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Index()
    {
        var customers = await context.Customers.ToListAsync();
        return View(customers);
    }

    public IActionResult Edit() => View();

    [HttpPut("{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, Customer newCustomer)
    {
        var customer = await context.Customers.FindAsync(id!);

        if (customer == null || !ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }

        customer.Name = newCustomer.Name;
        customer.BirthDate = newCustomer.BirthDate;
        
        context.Customers.Update(customer);
        await context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpGet]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int? id)
    {
        var customer = context.Customers.Find(id!);
        
        if (customer == null)
        {
            return RedirectToAction("Index");
        }

        context.Customers.Remove(customer);
        context.SaveChanges();
        
        return RedirectToAction("Index");
    }
}