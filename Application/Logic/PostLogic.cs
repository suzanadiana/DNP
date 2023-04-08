using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }
    
    
    private static void ValidateData(PostCreationDto postToCreate)
    {
        string title = postToCreate.postTitle;
        string body = postToCreate.postBody;
        

        if (title.Length > 150)
            throw new Exception("Title is too long!");
        if (body.Length > 10000)
            throw new Exception("The character limit is exceeded.");
    }


    public async Task<Post> CreatePost(PostCreationDto post)
    {
        {
            Post? existing = await postDao.GetByTitleAsync(post.postTitle);
            if (existing != null)
                throw new Exception("Title already taken!");
        }

        ValidateData(post);
        Post toCreate = new Post
        {
            postTitle = post.postTitle, postBody = post.postBody
        };
        
        Post created = await postDao.CreatePost(toCreate);
        
        return created;
    }

    public Task<IEnumerable<Post>> GetPosts(SearchPostDto searchParameters)
    {
        return postDao.GetPostsTask(searchParameters);
    }
}