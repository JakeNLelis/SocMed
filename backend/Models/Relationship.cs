using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Relationships")]
public class Relationship
{
  public string FollowingUserId { get; set;} = string.Empty;
  public AppUser? FollowingUser { get; set;}
  public string FollowedUserId { get; set; } = string.Empty;
  public AppUser? FollowedUser { get; set; }
}