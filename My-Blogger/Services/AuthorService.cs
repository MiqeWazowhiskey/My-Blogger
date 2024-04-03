using MyBlogger.Core.DTOs;
using MyBlogger.Core.Entities;
using MyBlogger.Core.Mappers;
using MyBlogger.Core.Wrappers;
using MyBlogger.Infrastructure.Contexts;

namespace My_Blogger.Services;

public class AuthorService
{
    private readonly MyBlogDbContext _context;
    private AuthorMapper _mapper;

    public AuthorService(MyBlogDbContext context, AuthorMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _context.ChangeTracker.Clear();
    }

    public async Task<Response<GetAuthorDto>> GetAuthor(Guid Id)
    {
        var author = await _context.Authors.FindAsync(Id);
        if (author is null)
        {
            throw new Exception("Author Not Found");
        }
        return new Response<GetAuthorDto>(_mapper.AuthorToGetAuthorDto(author), "Success");
    }

    public async Task<Response<GetAuthorDto>> UpdateAuthor(UpdateAuthorDto author)
    {
        var _author = await _context.Authors.FindAsync(author.Id);
        if (_author is null)
        {
            throw new Exception("Author Not Found");
        }
        if (author.Name is not null)
        {
            _author.Name = author.Name;
        }
        _author.CreationTime = new DateOnly();
        await _context.SaveChangesAsync();
        return new Response<GetAuthorDto>(_mapper.AuthorToGetAuthorDto(_author), "Success");
    }

    public async Task<Response<GetAuthorDto>> CreateAuthor(CreateAuthorDto author)
    {
        var _author = new Author()
        {
            Id = new Guid(),
            Name = author.Name,
            CreationTime = new DateOnly()
        };
        _context.Authors.Add(_author);
        await _context.SaveChangesAsync();
        return new Response<GetAuthorDto>(_mapper.AuthorToGetAuthorDto(_author), "Success");
    }

    public async Task<Response<bool>> DeleteAuthor(Guid Id)
    {
        var author = await _context.Authors.FindAsync(Id);
        if (author is null)
        {
            throw new Exception("Author Not Found");
        }
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return new Response<bool>(true,"Success");
    }
}
