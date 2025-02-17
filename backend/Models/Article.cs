namespace backend.Models;

public class Article
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    
    public int userId { get; set; }
    public User user { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    
}