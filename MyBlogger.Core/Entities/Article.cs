using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogger.Core.Entities;

public class Article
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    
    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; }
    public required string Title { get; set; } 
    public required string Body { get; set; }
    public required DateOnly CreationTime { get; set; }
}
