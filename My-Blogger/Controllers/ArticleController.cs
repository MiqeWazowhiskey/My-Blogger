using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Blogger.Data;


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
}
