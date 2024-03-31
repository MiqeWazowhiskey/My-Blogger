namespace My_Blogger.Dtos;

public record ArticleDto(Guid Id,Guid AuthorId, string Title, string Body, DateOnly CreationTime);
