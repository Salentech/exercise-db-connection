namespace exercise_db_connection.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public List<Review> Reviews { get; set; }
}