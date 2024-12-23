using exercise_db_connection.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace exercise_db_connection.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{

    public required DbSet<Book> Books { get; set; }
    public required DbSet<Review> Reviews { get; set; }
}