using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Repositories;

public class ReviewRepository(AppDbContext context)
{
    public async Task<List<Review>> GetReviewsByBookId(int bookId)
    {
        return await context.Reviews
            .Where(r => r.BookId == bookId)
            .ToListAsync();
    }

    public async Task AddReview(Review review)
    {
        context.Reviews.Add(review);
        await context.SaveChangesAsync();
    }
}