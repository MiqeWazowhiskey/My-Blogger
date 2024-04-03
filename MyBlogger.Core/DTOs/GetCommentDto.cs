namespace MyBlogger.Core.DTOs;

public record GetCommentDto(Guid Id,Guid UserId,Guid ArticleId, string? CommentBody, DateOnly CreationTime);
