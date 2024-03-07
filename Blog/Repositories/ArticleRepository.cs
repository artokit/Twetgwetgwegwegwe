using System.Data;
using System.Data.Common;
using Blog.Models;
using Dapper;
using WebApplication6.Repositories.Interfaces;

namespace WebApplication6.Repositories;
public class ArticleRepository: IArticleRepository
{
    private DbConnection _connection;

    public ArticleRepository(DbConnection connection)
    {
        this._connection = connection;
    }

    public async Task<List<Article>> GetAll()
    {
        return (await _connection.QueryAsync<Article>("select * from \"Articles\"")).ToList();
    }
}