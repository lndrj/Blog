using backend.Database;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : Controller
{
    private readonly AppDbContext _context;
    
    public ArticlesController(AppDbContext context)
    {
        _context = context;
    }
    
    // GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
    {
        return await _context.Articles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var article = await _context.Articles.FindAsync(id);

        if (article == null)
            return NotFound();
        
        return article;
    }
    
    [HttpPost]
    public async Task<ActionResult<Article>> PostArticle(Article article)
    {
        _context.Articles.Add(article);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetArticle", new { id = article.id }, article);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArticle(int id, Article article)
    {
        if (id != article.id)
        {
            return BadRequest();
        }

        _context.Entry(article).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ArticleExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null)
        {
            return NotFound();
        }

        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    private bool ArticleExists(int id)
    {
        return _context.Articles.Any(e => e.id == id);
    }
}