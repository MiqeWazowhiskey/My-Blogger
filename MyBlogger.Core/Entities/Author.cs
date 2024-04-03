using MyBlogger.Core.Entities;
namespace MyBlogger.Core.Entities;

public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly CreationTime { get; set; }
    
    public ICollection<Article> Articles { get; set; }
}
