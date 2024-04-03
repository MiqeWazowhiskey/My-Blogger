using MyBlogger.Core.DTOs;
using MyBlogger.Core.Entities;

namespace MyBlogger.Core.Mappers;

public class ArticleMapper
{
    public GetArticleDto ArticleToGetArticleDto(Article article)
    {
        return new GetArticleDto(
            article.Id,
            article.AuthorId,
            article.Title,
            article.Body,
            article.CreationTime
        );
    }
    public GetAllArticlesDto ArticlesToGetAllArticlesDto(List<Article> articles)
    {
        var _articles = articles.Select(article => ArticleToGetArticleDto(article)).ToList();
        return new GetAllArticlesDto(_articles);
    }
}
