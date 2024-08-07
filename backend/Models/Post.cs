using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Posts")]
public class Post
{
    public int Id { get; set;}
    public string Caption { get; set;} = string.Empty;
    public string AppUserId { get; set;} = string.Empty;
    public AppUser? AppUser { get; set;}
    public List<LikedPost> Likes { get; set;} = new List<LikedPost>();
    public List<Comment> Comments { get; set;} = new List<Comment>();
}