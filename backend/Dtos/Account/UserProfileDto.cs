using backend.Models;

namespace backend.Dtos.Account;

public class UserProfileDto
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? Birthdate { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Country { get; set; }
    public string? ProfilePhoto { get; set; }
    public string? CoverPhoto { get; set; }
    public string? Bio { get; set; }
    public List<Post> Posts { get; set; } = [];
    public List<Relationship> Followings { get; set; } = [];
    public List<Relationship> Followers { get; set; } = [];
}
