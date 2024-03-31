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
    }
    [HttpGet]
    public async Task<IActionResult> GetAllArticles()
    {
        var articles = await _context.Articles.ToListAsync();
        return Ok(articles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticle(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        return article is null ? BadRequest("Article Not Found.") : Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto article)
    {
        var _article = new Article()
        {
            Id = 123,
            AuthorId = article.AuthorId,
            CreationTime = new DateOnly(),
            Title = article.Title,
            Body = article.Body
        };
        _context.Articles.Add(_article);
        await _context.SaveChangesAsync();
        return Ok(_article);
    }

    [HttpPatch("{id}")]
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
}
