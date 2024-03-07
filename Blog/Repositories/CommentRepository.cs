using System.Data;
using System.Data.Common;
using Blog.Models;
using Dapper;
using WebApplication6.Repositories.Interfaces;

namespace WebApplication6.Repositories;

public class CommentRepository : ICommentRepository
{
    private IDbConnection _connection;

    public CommentRepository(DbConnection connection)
    {
        _connection = connection;
    }
    
    public async Task<Comment> GetComment(int id)
    {
        return await _connection.QueryFirstAsync<Comment>("SELECT * FROM \"Comments\" WHERE \"Id\" = @id", new {id});
    }
}