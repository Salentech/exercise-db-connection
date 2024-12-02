using exercise_db_connection.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
}