using exercise_db_connection.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Repositories;

public class BookRepository(AppDbContext context)
{
    internal Task<List<Book>> GetAll(int skip, int take)
    {
        return context.Books
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    internal Task<Book?> GetById(int bookId)
    {
        return context.Books
            .FirstOrDefaultAsync(book => book.Id == bookId);
    }
}