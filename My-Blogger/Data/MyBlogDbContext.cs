using Microsoft.EntityFrameworkCore;
using My_Blogger.Entities;

namespace My_Blogger.Data;

public class MyBlogDbContext : DbContext
{
    public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options){}
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Author> Authors => Set<Author>();
}
