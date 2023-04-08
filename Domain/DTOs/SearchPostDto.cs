namespace Domain.DTOs;

public class SearchPostDto
{
    public string? PostContains { get;  }

    public SearchPostDto(string? postContains)
    {
        PostContains = postContains;
    }
}