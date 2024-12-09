using System.Diagnostics;
using exercise_db_connection.Models;
using exercise_db_connection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise_db_connection.Controllers;

public class BookController(ILogger<HomeController> logger, BookRepository bookRepository)
    : Controller
{
    public async Task<IActionResult> Books(int bookId)
    {
        var book = await bookRepository.GetById(bookId);
        if (book == null) return NotFound();

        ViewBag.book = book;
    


        return View(book);
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}