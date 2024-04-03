using MyBlogger.Core.DTOs;
using MyBlogger.Core.Wrappers;

namespace MyBlogger.Core.Interfaces;

public interface ICommentService
{
    Task<Response<GetAllCommentsByIdDto>> GetAllCommentsById(Guid Id);
    Task<Response<GetCommentDto>> GetCommentById(Guid Id);

    Task<Response<GetCommentDto>> CreateComment(CreateCommentDto comment);
    Task<Response<GetCommentDto>> UpdateComment(UpdateCommentDto comment);
    Task<Response<bool>> DeleteComment(Guid Id);
}
