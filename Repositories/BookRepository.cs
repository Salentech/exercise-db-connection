using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Repositories
{
    public class BookRepository(AppDbContext context)
    {
        internal async Task<List<Book>> GetAll(int skip, int take)
        {
            var books = await context.Books
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return books;
        }
    }
}
