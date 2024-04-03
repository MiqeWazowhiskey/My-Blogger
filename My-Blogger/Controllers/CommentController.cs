using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Blogger.Services;
using MyBlogger.Core.DTOs;

namespace My_Blogger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController: ControllerBase
{
    private CommentService _commentService;

    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("{id}"), Authorize]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        return Ok(await _commentService.GetCommentById(id));
    }

    [HttpGet("/GetByArticleId/{id}"),Authorize]
    public async Task<IActionResult> GetCommentsByArticleId(Guid id)
    {
        return Ok(await _commentService.GetAllCommentsById(id));
    }

    [HttpPost,Authorize]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto comment)
    {
        return Ok(await _commentService.CreateComment(comment));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto comment)
    {
        return Ok(await _commentService.UpdateComment(comment));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        return Ok(await _commentService.DeleteComment(id));
    }
}
