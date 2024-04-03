using MyBlogger.Core.DTOs;
using MyBlogger.Core.Wrappers;


namespace MyBlogger.Core.Interfaces;

public interface IArticleService
{ 
    Task<Response<GetAllArticlesDto>> GetAllArticles();
    Task<Response<GetArticleDto>> GetArticle(Guid Id);
    Task<Response<GetArticleDto>> UpdateArticle(UpdateArticleDto article);
    Task<Response<GetArticleDto>> CreateArticle(CreateArticleDto article);
    Task<Response<bool>> DeleteArticle(Guid Id);
}
