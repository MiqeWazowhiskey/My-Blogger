namespace My_Blogger.Entities;

public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly CreationTime { get; set; }
}
