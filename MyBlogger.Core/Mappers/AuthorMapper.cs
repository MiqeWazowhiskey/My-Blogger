using MyBlogger.Core.DTOs;
using MyBlogger.Core.Entities;

namespace MyBlogger.Core.Mappers;

public class AuthorMapper
{
    public GetAuthorDto AuthorToGetAuthorDto(Author author)
    {
        return new GetAuthorDto(
            author.Id,
            author.Name,
            author.CreationTime
        );
    }
}
