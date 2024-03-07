using Blog.Models;

namespace WebApplication6.Repositories.Interfaces;

public interface IArticleRepository
{
    public Task<List<Article>> GetAll();
}