using AutoMapper;
using exercise_db_connection.Models;
using exercise_db_connection.Models.Dtos;
using exercise_db_connection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise_db_connection.Controllers;

public class ReviewController(
    ILogger<HomeController> logger,
    ReviewRepository reviewRepository,
    BookRepository bookRepository,
    IMapper mapper)
    : Controller
{
    public async Task<IActionResult> Reviews(int bookid)
    {
        var book = await bookRepository.GetById(bookid);
        if (book == null) return NotFound();

        var reviews = await reviewRepository.GetReviewsByBookId(bookid);

        ViewBag.Book = book;
        ViewBag.Reviews = reviews;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(ReviewDto reviewDto)
    {
        if (ModelState.IsValid) await reviewRepository.AddReview(mapper.Map<Review>(reviewDto));
        return RedirectToAction("Reviews", new { bookid = reviewDto.BookId });
    }
}