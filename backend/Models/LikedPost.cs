using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("LikedPosts")]
public class LikedPost
{
  public string LikeUserId { get; set; } = "";
  public AppUser? LikeUser { get; set; }
  public int PostId { get; set; }
  public Post? Post { get; set; }
  public DateTime LikedOn { get; set; } = DateTime.Now;
}