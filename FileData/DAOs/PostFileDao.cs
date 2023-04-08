using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreatePost(Post post)
    {
        
        context.Posts.Add(post);
        context.SaveChanges();

        return await Task.FromResult(post);
    }

    public Task<Post?> GetByTitleAsync(string title)
    {
        Post? existing = context.Posts.FirstOrDefault(u =>
            u.postTitle.Equals(title, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetPostsTask(SearchPostDto searchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
     
        if (searchParameters.PostContains != null)
        { 
            posts = context.Posts.Where(u => u.postTitle.Contains(searchParameters.PostContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(posts);
    }
    }

