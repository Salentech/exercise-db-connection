using exercise_db_connection.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace exercise_db_connection.Test.example_db_connection_test.Repositories
{
    public class BookRepositoryTests
    {
        private readonly BookRepository _repository;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            var context = new AppDbContext(options);
            _repository = new BookRepository(context);

            context.Books.AddRange(
                new Book { Title = "Book 1", Author = "Author 1" },
                new Book { Title = "Book 2", Author = "Author 2" }
            );
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAll_ReturnsBooksWithPagination()
        {
            var books = await _repository.GetAll(0, 1);

            Assert.NotNull(books);
            Assert.Single(books);
            Assert.Equal("Book 1", books.First().Title);
        }

        [Fact]
        public async Task GetById_ReturnsBookForGivenId()
        {
            var book = await _repository.GetById(1);

            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
            Assert.Equal("Book 1", book.Title);
        }

        [Fact]
        public async Task GetById_ReturnsNullForNonExistingBook()
        {
            var book = await _repository.GetById(999);

            Assert.Null(book);
        }
    }
}