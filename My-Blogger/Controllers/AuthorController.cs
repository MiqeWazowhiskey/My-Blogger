using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Blogger.Services;
using MyBlogger.Core.DTOs;

namespace My_Blogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{

    private AuthorService _authorService;
    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("{id}"),Authorize]
    public async Task<IActionResult> GetAuthor(Guid id)
    {
        return Ok(await _authorService.GetAuthor(id));
    }

    [HttpPost,Authorize]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto author)
    {
        return Ok(await _authorService.CreateAuthor(author));
    }

    [HttpPut,Authorize]
    public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDto author)
    {
        return Ok(await _authorService.UpdateAuthor(author));
    }

    [HttpDelete("{id}"),Authorize]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        return Ok(await _authorService.DeleteAuthor(id));
    }
    
}
