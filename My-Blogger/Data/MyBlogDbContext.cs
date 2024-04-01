using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Blogger.Entities;

namespace My_Blogger.Data;

public class MyBlogDbContext : IdentityDbContext<IdentityUser>
{
    public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options){}
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Comment> Comments => Set<Comment>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Article>()
            .HasOne<Article>()
            .WithMany().HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne<Comment>()
            .WithMany().HasForeignKey(a => a.ArticleId).OnDelete(DeleteBehavior.Restrict);
    }
}
