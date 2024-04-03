using Microsoft.EntityFrameworkCore;
using MyBlogger.Core.DTOs;
using MyBlogger.Core.Entities;
using MyBlogger.Core.Interfaces;
using MyBlogger.Core.Mappers;
using MyBlogger.Core.Wrappers;
using MyBlogger.Infrastructure.Contexts;

namespace My_Blogger.Services;

public class CommentService : ICommentService
{
    private readonly MyBlogDbContext _context;
    private CommentMapper _mapper;

    public CommentService(MyBlogDbContext context, CommentMapper mapper)
    {
        _mapper = mapper;
        _context = context;
        _context.ChangeTracker.Clear();
    }

    public async Task<Response<GetAllCommentsByIdDto>> GetAllCommentsById(Guid Id)
    {
        var comments = await _context.Comments.Where(v => v.ArticleId == Id).ToListAsync();
        return new Response<GetAllCommentsByIdDto>(_mapper.CommentsToGetAllCommentsDto(comments));
    }

    public async Task<Response<GetCommentDto>> GetCommentById(Guid Id)
    {
        var comment = await _context.Comments.FindAsync(Id);
        if (comment is null)
        {
            throw new Exception("Comment Not Found");
        }

        return new Response<GetCommentDto>(_mapper.CommentToGetCommentDto(comment));
    }

    public async Task<Response<GetCommentDto>> CreateComment(CreateCommentDto comment)
    {
        var article = await _context.Articles.FindAsync(comment.ArticleId);
        if (article is null)
        {
            throw new Exception("Article Not Found");
        }
        var _comment = new Comment()
        {
            Id = new Guid(),
            ArticleId = comment.ArticleId,
            CommentBody = comment.CommentBody,
            UserId = comment.UserId,
            Article = article,
            CreationTime = new DateOnly()
        };
        _context.Add(_comment);
        await _context.SaveChangesAsync();
        return new Response<GetCommentDto>(_mapper.CommentToGetCommentDto(_comment));
    }

    public async Task<Response<GetCommentDto>> UpdateComment(UpdateCommentDto comment)
    {
        var _comment = await _context.Comments.FindAsync(comment.Id);
        if (_comment is null)
        {
            throw new Exception("Comment Not Found");
        }

        if (comment.CommentBody is not null)
        {
            _comment.CommentBody = comment.CommentBody;
        }
        await _context.SaveChangesAsync();
        return new Response<GetCommentDto>(_mapper.CommentToGetCommentDto(_comment));
    }

    public async Task<Response<bool>> DeleteComment(Guid id)
    {
        var _comment = await _context.Comments.FindAsync(id);
        if (_comment is null)
        {
            throw new Exception("Comment Not Found");
        }

        _context.Comments.Remove(_comment);
        await _context.SaveChangesAsync();
        return new Response<bool>(true,"Success");
    }
}
