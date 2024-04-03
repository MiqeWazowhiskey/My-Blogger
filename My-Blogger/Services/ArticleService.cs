using Microsoft.EntityFrameworkCore;
using MyBlogger.Core.DTOs;
using MyBlogger.Core.Entities;
using MyBlogger.Core.Interfaces;
using MyBlogger.Infrastructure.Contexts;
using MyBlogger.Core.Mappers;
using MyBlogger.Core.Wrappers;

namespace My_Blogger.Services;

public class ArticleService : IArticleService
{
    private readonly MyBlogDbContext _context;
    private ArticleMapper _mapper;

    public ArticleService(MyBlogDbContext context, ArticleMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _context.ChangeTracker.Clear();
    }
    
    public async Task<Response<GetAllArticlesDto>> GetAllArticles()
    {
        var articles = await _context.Articles.ToListAsync();
        return new Response<GetAllArticlesDto>(_mapper.ArticlesToGetAllArticlesDto(articles), "Success");
    }

    public async Task<Response<GetArticleDto>> GetArticle(Guid Id)
    {
        var article = await _context.Articles.FindAsync(Id);
        if (article is null)
        {
            throw new Exception("Article Not Found");
        }
        return new Response<GetArticleDto>(_mapper.ArticleToGetArticleDto(article), "Success");
    }

    public async Task<Response<GetArticleDto>> UpdateArticle(UpdateArticleDto article)
    {
        var _article = await _context.Articles.FindAsync(article.Id);
        if (_article is null)
        {
            throw new Exception("Article Not Found");
        }
        if (article.Title is not null)
        {
            _article.Title = article.Title;
        }

        if (article.Body is not null)
        {
            _article.Body = article.Body;
        }
        _article.CreationTime = new DateOnly();
        await _context.SaveChangesAsync();
        return new Response<GetArticleDto>(_mapper.ArticleToGetArticleDto(_article), "Success");
    }
    
    public async Task<Response<GetArticleDto>> CreateArticle(CreateArticleDto article)
    {
        var author = await _context.Authors.FindAsync(article.AuthorId);
        if (author is null)
        {
            throw new Exception("Author Not Found");
        }
        var _article = new Article()
        {
            Id = new Guid(),
            AuthorId = article.AuthorId,
            CreationTime = new DateOnly(),
            Title = article.Title,
            Body = article.Body,
            Author = author
        };
        _context.Articles.Add(_article);
        await _context.SaveChangesAsync();
        return new Response<GetArticleDto>(_mapper.ArticleToGetArticleDto(_article), "Success");
    }

    public async Task<Response<bool>> DeleteArticle(Guid Id)
    {
        var article = await _context.Articles.FindAsync(Id);
        if (article is null)
        {
            throw new Exception("Article Not Found");
        }
        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
        return new Response<bool>(true,"Success");
    }
}
