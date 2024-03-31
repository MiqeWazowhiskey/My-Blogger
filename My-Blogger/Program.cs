using Microsoft.EntityFrameworkCore;
using My_Blogger.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyBlogDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
var app = builder.Build();



app.MapGet("/articles", async (MyBlogDbContext dbContext) =>
{
    var articles = await dbContext.Articles.ToListAsync();
    return Results.Ok(articles);
});

app.Run();
