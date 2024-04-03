using MyBlogger.Core.Entities;

namespace MyBlogger.Core.DTOs;

public record GetAuthorDto(Guid Id, string Name, DateOnly CreationTime);
