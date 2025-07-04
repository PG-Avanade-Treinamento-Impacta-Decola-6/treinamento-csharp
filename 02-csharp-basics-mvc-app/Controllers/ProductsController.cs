using Microsoft.AspNetCore.Mvc;

namespace _02_csharp_basics_mvc_app.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        List<string> products = new List<string>
        {
            "Banana",
            "Maçã",
            "Laranja",
            "Uva",
            "Pera",
            "Manga"
        };

        return View(products);

    }
}
