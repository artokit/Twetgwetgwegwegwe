using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Repositories.Interfaces;

namespace WebApplication6.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController
{
    private ICommentRepository _commentRepository;

    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<Comment> GetComment(int id)
    {
        var res = await _commentRepository.GetComment(id);
        Console.WriteLine(res);
        return res;
    }
}