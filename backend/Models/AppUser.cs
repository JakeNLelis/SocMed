using Microsoft.AspNetCore.Identity;

namespace backend.Models;

public class AppUser : IdentityUser
{
  public string FirstName { get; set; } = string.Empty;
  public string? MiddleName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateTime? Birthdate { get; set; }
  public string? City { get; set; }
  public string? Province { get; set; }
  public string? Country { get; set; }
  public string? ProfilePhoto { get; set; }
  public string? CoverPhoto { get; set; }
  public string? Bio { get; set; }
  public List<Post> Posts{ get; set; } = new();
  public List<Comment> Comments{ get; set; } = new();
  public List<Relationship> Followings { get; set; } = new();
  public List<Relationship> Followers { get; set; } = new(); 
  public List<LikedPost> Likes { get; set; } = new();
}