using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using exercise_db_connection.Models;

namespace exercise_db_connection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        
        return View();
    }

        public IActionResult Books()
    {
        string[] books = [];
        books=["Mille e una notte","I Miserabili","Alice nel paese delle meraviglie"];
        ViewBag.Books = books;
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
