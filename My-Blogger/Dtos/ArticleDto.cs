namespace My_Blogger.Dtos;

public record ArticleDto(int Id,int AuthorId, string Title, string Body, DateOnly CreationTime);
