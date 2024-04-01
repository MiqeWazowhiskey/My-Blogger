using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Blogger.Data;
using My_Blogger.Dtos;
using My_Blogger.Entities;

namespace My_Blogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private readonly MyBlogDbContext _context;

    public ArticleController(MyBlogDbContext context)
    {
        _context = context;
        _context.ChangeTracker.Clear();
    }
    [HttpGet,Authorize]
    public async Task<IActionResult> GetAllArticles()
    {
        var articles = await _context.Articles.ToListAsync();
        return Ok(articles);
    }

    [HttpGet("{id}"),Authorize]
    public async Task<IActionResult> GetArticle(Guid id)
    {
        var article = await _context.Articles.FindAsync(id);
        return article is null ? BadRequest("Article Not Found.") : Ok(article);
    }

    [HttpPost,Authorize]
    public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto article)
    {
        var _article = new Article()
        {
            Id = new Guid(),
            AuthorId = article.AuthorId,
            CreationTime = new DateOnly(),
            Title = article.Title,
            Body = article.Body
        };
        _context.Articles.Add(_article);
        await _context.SaveChangesAsync();
        return Ok(_article);
    }

    [HttpPatch("{id}"),Authorize]
    public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleDto article)
    {
        var _article = await _context.Articles.FindAsync(article.Id);
        if (_article is null)
        {
            return BadRequest("Article Not Found.");
        }
        if (article.Title is not null)
        {
            _article.Title = article.Title;
        }

        if (article.Body is not null)
        {
            _article.Body = article.Body;
        }
        _article.CreationTime = new DateOnly();
        await _context.SaveChangesAsync();
        return Ok(_article);
    }

    [HttpDelete("{id}"),Authorize]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article is null)
        {
            return BadRequest("ArticleNotFound");
        }
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
}
