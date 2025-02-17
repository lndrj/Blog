namespace backend.Models;

public class User
{
    public int id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;
    
    public ICollection<Comment> Comments { get; set; }
    
    public ICollection<Article> Articles { get; set; }
}