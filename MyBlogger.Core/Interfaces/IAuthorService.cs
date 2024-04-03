using MyBlogger.Core.DTOs;
using MyBlogger.Core.Wrappers;

namespace MyBlogger.Core.Interfaces;

public interface IAuthorService
{
    Task<Response<GetAuthorDto>> GetAuthor(Guid Id);
    Task<Response<GetAuthorDto>> UpdateAuthor(UpdateAuthorDto article);
    Task<Response<GetAuthorDto>> CreateAuthor(CreateAuthorDto article);
    Task<Response<bool>> DeleteAuthor(Guid Id);
}
