using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Blogger.Data;
using My_Blogger.Dtos;
using My_Blogger.Entities;

namespace My_Blogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly MyBlogDbContext _context;

    public AuthorController(MyBlogDbContext context)
    {
        _context = context;
        _context.ChangeTracker.Clear();
    }

    [HttpGet("{id}"),Authorize]
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);
        return author is null ? BadRequest("Author Not Found") : Ok(author);
    }

    [HttpPost,Authorize]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto author)
    {
        var _author = new Author()
        {
            Id = new Guid(),
            Name = author.Name,
            CreationTime = new DateOnly()
        };
        _context.Authors.Add(_author);
        await _context.SaveChangesAsync();
        return Ok(_author);
    }

    [HttpPut,Authorize]
    public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto author)
    {
        var _author = await _context.Authors.FindAsync(author.Id);
        if (_author is null)
        {
            return BadRequest("Author Not Found");
        }

        _author.Name = author.Name;
        _author.CreationTime = new DateOnly();
        await _context.SaveChangesAsync();
        return Ok(_author);
    }

    [HttpDelete("{id}"),Authorize]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author is null)
        {
            return BadRequest("Author Not Found.");
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}
