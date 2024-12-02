using System.Diagnostics;
using exercise_db_connection.Models;
using exercise_db_connection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise_db_connection.Controllers;

public class HomeController(ILogger<HomeController> logger, BookRepository bookRepository)
    : Controller
{
    public async Task<IActionResult> Index(int skip = 0, int take = 5)
    {
        List<Book> books = await bookRepository.GetAll(skip, take + 1);

        ViewBag.Books = books.Take(take).ToList();
        ViewBag.Skip = skip;
        ViewBag.Take = take;

        ViewBag.hasNextPage = books.Count > take;
        return View();
    }

    public IActionResult Books()
    {
        string[] books = ["Mille e una notte", "I Miserabili", "Alice nel paese delle meraviglie"];
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