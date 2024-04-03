using MyBlogger.Core.Entities;

namespace MyBlogger.Core.DTOs;

public record GetArticleDto(Guid Id, Guid AuthorId, string Title, string Body, DateOnly CreationTime);
