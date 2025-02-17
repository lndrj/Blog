using backend.Database;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: api/Users/Register
    [HttpPost("Register")]
    public async Task<ActionResult<User>> RegisterUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.id }, user);
    }

    // POST: api/Users/Login
    [HttpPost("Login")]
    public async Task<ActionResult<User>> LoginUser(User user)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.email == user.email && u.password == user.password);

        if (existingUser == null)
        {
            return Unauthorized();
        }

        return Ok(existingUser);
    }
}
