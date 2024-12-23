using exercise_db_connection.Data;
using exercise_db_connection.Models;
using exercise_db_connection.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace exercise_db_connection.Test.example_db_connection_test.Repositories;

public class ReviewRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly ReviewRepository _repository;

    public ReviewRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _context = new AppDbContext(options);
        _repository = new ReviewRepository(_context);

        var book1 = new Book { Title = "Book 1", Author = "Author 1" };
        var book2 = new Book { Title = "Book 2", Author = "Author 2" };

        _context.Books.AddRange(book1, book2);
        _context.SaveChanges();

        _context.Reviews.AddRange(
            new Review { BookId = book1.Id, ReviewerName = "Alice", Content = "Great book!", Rating = 5, Book = book1 },
            new Review { BookId = book1.Id, ReviewerName = "Bob", Content = "Not bad", Rating = 3, Book = book1 },
            new Review
            {
                BookId = book2.Id, ReviewerName = "Charlie", Content = "Could be better", Rating = 2, Book = book2
            }
        );
        _context.SaveChanges();
    }

    [Fact]
    public async Task GetReviewsByBookId_ReturnsReviewsForGivenBookId()
    {
        var reviews = await _repository.GetReviewsByBookId(1, 0, 5);

        Assert.NotNull(reviews);
        Assert.Equal(2, reviews.Count);
        Assert.All(reviews, review => Assert.Equal(1, review.BookId));
    }

    [Fact]
    public async Task AddReview_AddsNewReview()
    {
        var book = await _context.Books.FirstAsync(b => b.Id == 2);
        var newReview = new Review
            { BookId = book.Id, ReviewerName = "David", Content = "Amazing!", Rating = 4, Book = book };

        await _repository.AddReview(newReview);

        var reviews = await _repository.GetReviewsByBookId(2, 0, 5);
        Assert.Contains(reviews, r => r.Content == "Amazing!");
        Assert.Contains(reviews, r => r.ReviewerName == "David");
        Assert.Contains(reviews, r => r.Rating == 4);
    }
}