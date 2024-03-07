using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Repositories.Interfaces;

namespace WebApplication6.Controllers;
[ApiController]
[Route("Article")]
public class ArticleController
{
    private readonly IArticleRepository _articleRepository;

    public ArticleController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet]
    public async Task<List<Article>> GetAll()
    {
        return await _articleRepository.GetAll();
    }
    
}

