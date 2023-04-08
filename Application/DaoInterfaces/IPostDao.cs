using Domain;
using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreatePost(Post post);
    Task<Post?> GetByTitleAsync(string title);
    public Task<IEnumerable<Post>> GetPostsTask(SearchPostDto searchParameters);
}