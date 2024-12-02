using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Repositories
{
    public class BookRepository
    {

        private readonly AppDbContext _appContext;

        public BookRepository(AppDbContext context)
        {
            _appContext = context;
        }
        
        internal async Task<List<Book>> GetAll(int Skip, int Take)
        {
            var books = await _appContext.Books
                .Skip(Skip)
                .Take(Take)
                .ToListAsync();
            return books;
        }
    }
}
