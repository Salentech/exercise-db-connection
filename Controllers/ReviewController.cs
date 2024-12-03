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
    public async Task<IActionResult> Reviews(int bookid, int skip = 0, int take = 5)
    {
        var book = await bookRepository.GetById(bookid);
        if (book == null) return NotFound();

        var reviews = await reviewRepository.GetReviewsByBookId(bookid, skip, take + 1);

        ViewBag.Book = book;
        ViewBag.Reviews = reviews.Take(take).ToList();
        ViewBag.Skip = skip;
        ViewBag.Take = take;
        
        ViewBag.hasNextPage = reviews.Count > take;
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> AddReview(ReviewDto reviewDto)
    {
        if (ModelState.IsValid) await reviewRepository.AddReview(mapper.Map<Review>(reviewDto));
        return RedirectToAction("Reviews", new { bookid = reviewDto.BookId });
    }
}