namespace MyBlogger.Core.DTOs;

public record CreateCommentDto(string CommentBody, Guid ArticleId, Guid UserId);
