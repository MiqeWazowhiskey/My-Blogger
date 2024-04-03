using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Blogger.Services;
using MyBlogger.Core.DTOs;

namespace My_Blogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleController : ControllerBase
{
    private ArticleService _articleService;

    public ArticleController(ArticleService articleService)
    {
        _articleService = articleService;
    }
    [HttpGet,Authorize]
    public async Task<IActionResult> GetAllArticles()
    {
        return Ok(await _articleService.GetAllArticles());
    }

    [HttpGet("{id}"),Authorize]
    public async Task<IActionResult> GetArticle(Guid id)
    {
        return Ok(await _articleService.GetArticle(id));
    }

    [HttpPost,Authorize]
    public async Task<IActionResult> CreateArticle([FromBody] CreateArticleDto article)
    {
        return Ok(await _articleService.CreateArticle(article));
    }

    [HttpPatch("{id}"),Authorize]
    public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleDto article)
    {
        return Ok(await _articleService.UpdateArticle(article));
    }

    [HttpDelete("{id}"),Authorize]
    public async Task<IActionResult> DeleteArticle(Guid id)
    {
        return Ok(await _articleService.DeleteArticle(id));
    }
    
}
