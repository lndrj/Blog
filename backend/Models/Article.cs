namespace backend.Models;

public enum Category
{
    Lifestyle,
    Health,
    Entertainment,
    Technology,
    Politics
}

public class Article
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string content { get; set; }
    public Category category { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;
    public DateTime updatedAt { get; set; } = DateTime.Now;
    
    public int authorId { get; set; }
    public User author { get; set; }
    
    public ICollection<Comment> Comments { get; set; }
    
}