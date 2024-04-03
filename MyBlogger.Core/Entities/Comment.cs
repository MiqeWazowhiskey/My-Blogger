using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogger.Core.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public required Guid ArticleId { get; set; }
    public required Guid UserId { get; set; }
    
    [MaxLength(500)]
    public required string CommentBody { get; set; }
    
    public required DateOnly CreationTime { get; set; }
    
    [ForeignKey(nameof(ArticleId))]
    public Article Article { get; set; }
}
