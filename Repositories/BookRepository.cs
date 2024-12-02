using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Repositories
{
    public class BookRepository
    {

        private readonly AppDbContext appContext;

        public BookRepository(AppDbContext context)
        {
            appContext = context;
        }
        
        internal async Task<List<Book>> GetAll(int skip, int take)
        {
            var books = await appContext.Books
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return books;
        }
    }
}
