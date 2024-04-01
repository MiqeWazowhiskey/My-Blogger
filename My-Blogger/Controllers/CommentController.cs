using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Blogger.Data;
using My_Blogger.Dtos;
using My_Blogger.Entities;

namespace My_Blogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController: ControllerBase
{
    private MyBlogDbContext _context;

    public CommentController(MyBlogDbContext context)
    {
        _context = context;
        _context.ChangeTracker.Clear();
    }

    [HttpGet("{id}"), Authorize]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var comment = await _context.Comments.FindAsync(id);
        return comment is null ? BadRequest("Commend Not Found") : Ok(comment);
    }

    [HttpGet("/GetByArticleId/{id}"),Authorize]
    public async Task<IActionResult> GetCommentsByArticleId(Guid id)
    {
        var comments = await _context.Comments.Where(v => v.ArticleId == id).ToListAsync();
        return Ok(comments);
    }

    [HttpPost,Authorize]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto comment)
    {
        var _comment = new Comment()
        {
            Id = new Guid(),
            ArticleId = comment.ArticleId,
            CommentBody = comment.CommentBody,
            UserId = comment.UserId,
            CreationTime = new DateOnly()
        };
        _context.Add(_comment);
        await _context.SaveChangesAsync();
        return Ok(comment);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto comment)
    {
        var _comment = await _context.Comments.FindAsync(comment.Id);
        if (_comment is null)
        {
            return BadRequest("Comment Not Found");
        }

        _comment.CommentBody = comment.CommentBody;
        _comment.CreationTime = new DateOnly();
        await _context.SaveChangesAsync();
        return Ok(_comment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var _comment = await _context.Comments.FindAsync(id);
        if (_comment is null)
        {
            return BadRequest("Comment Not Found");
        }
        _context.Comments.Remove(_comment);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
