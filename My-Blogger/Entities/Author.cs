namespace My_Blogger.Entities;

public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly CreationTime { get; set; }
}
