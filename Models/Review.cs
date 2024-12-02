namespace exercise_db_connection.Models;

public class Review
{
    public int Id { get; set; }
    public string ReviewerName { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
}