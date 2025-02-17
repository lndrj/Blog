namespace backend.Models;

public class Comment
{
    public int id { get; set; }
    public string content { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;
    public int userId { get; set; }
    public User User { get; set; }
    
    public int articleId { get; set; }
    public Article Article { get; set; }
}