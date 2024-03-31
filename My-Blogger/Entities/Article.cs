namespace My_Blogger.Entities;

public class Article
{
    public Guid Id { get; set; }
    public required Guid AuthorId { get; set; }
    public required string Title { get; set; } 
    public required string Body { get; set; }
    public required DateOnly CreationTime { get; set; }
}
