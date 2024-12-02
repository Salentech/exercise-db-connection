using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using exercise_db_connection.Models;
using exercise_db_connection.Repositories;

namespace exercise_db_connection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private BookRepository _bookRepository;

    public HomeController(ILogger<HomeController> logger, BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        List<Book> books = await _bookRepository.GetAll();
        ViewBag.Books = books;
        
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
