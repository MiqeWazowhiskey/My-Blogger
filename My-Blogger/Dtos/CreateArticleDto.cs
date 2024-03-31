namespace My_Blogger.Dtos;

public record CreateArticleDto(Guid AuthorId, string Title, string Body);
