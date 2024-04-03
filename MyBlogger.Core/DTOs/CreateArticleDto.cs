namespace MyBlogger.Core.DTOs;

public record CreateArticleDto(Guid AuthorId, string Title, string Body);
