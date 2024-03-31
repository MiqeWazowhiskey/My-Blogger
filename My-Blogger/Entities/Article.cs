namespace My_Blogger.Entities;

public class Article
{
    public int Id { get; set; }
    public required int AuthorId { get; set; }
    public required string Title { get; set; } 
    public required string Body { get; set; }
    public required DateOnly CreationTime { get; set; }
}
