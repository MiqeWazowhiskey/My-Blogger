namespace My_Blogger.Dtos;

public record CreateCommentDto(string CommentBody, Guid ArticleId, Guid UserId);
