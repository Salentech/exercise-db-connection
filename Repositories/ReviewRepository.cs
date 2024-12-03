using exercise_db_connection.Data;
using exercise_db_connection.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Repositories;

public class ReviewRepository(AppDbContext context)
{
    public async Task<List<Review>> GetReviewsByBookId(int bookId, int skip, int take)
    {
        return await context.Reviews
            .Where(r => r.BookId == bookId)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task AddReview(Review review)
    {
        context.Reviews.Add(review);
        await context.SaveChangesAsync();
    }
}