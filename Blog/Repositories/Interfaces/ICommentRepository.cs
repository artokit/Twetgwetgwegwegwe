using Blog.Models;

namespace WebApplication6.Repositories.Interfaces;

public interface ICommentRepository
{
    public Task<Comment> GetComment(int id);
}