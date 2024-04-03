namespace MyBlogger.Core.DTOs;

public record UpdateArticleDto(Guid Id, string? Title, string? Body);
