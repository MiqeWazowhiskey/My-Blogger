namespace MyBlogger.Core.DTOs;

public record ArticleDto(Guid Id,Guid AuthorId, string Title, string Body, DateOnly CreationTime);
ö
