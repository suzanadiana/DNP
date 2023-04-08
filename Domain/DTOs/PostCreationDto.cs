namespace Domain.DTOs;

public class PostCreationDto
{
    public String postTitle { get; }
    public String postBody { get; }

    public PostCreationDto(String postTitle, String postBody)
    {
        this.postTitle = postTitle;
        this.postBody = postBody;
    }
}