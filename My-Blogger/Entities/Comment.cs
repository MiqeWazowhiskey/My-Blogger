using System.ComponentModel.DataAnnotations;

namespace My_Blogger.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public required Guid ArticleId { get; set; }
    public required Guid UserId { get; set; }
    
    [MaxLength(500)]
    public required string CommentBody { get; set; }
    
    public required DateOnly CreationTime { get; set; }
}
