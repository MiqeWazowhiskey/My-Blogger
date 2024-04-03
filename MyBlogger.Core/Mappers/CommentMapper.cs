using MyBlogger.Core.DTOs;
using MyBlogger.Core.Entities;

namespace MyBlogger.Core.Mappers;

public class CommentMapper
{
    public GetCommentDto CommentToGetCommentDto(Comment comment)
    {
        return new GetCommentDto(comment.Id, comment.UserId, comment.ArticleId, comment.CommentBody, comment.CreationTime);
    }
    public GetAllCommentsByIdDto CommentsToGetAllCommentsDto(List<Comment> comments)
    {
        var _comments = comments.Select(comment => CommentToGetCommentDto(comment)).ToList();
        return new GetAllCommentsByIdDto(_comments);
    }
}
