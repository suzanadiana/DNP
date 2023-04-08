using Domain;
using Domain.DTOs;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreatePost(PostCreationDto post);  
    public Task<IEnumerable<Post>> GetPosts(SearchPostDto searchParameters);
}