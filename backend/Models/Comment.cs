using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("Comments")]
public class Comment
{
    public int Id { get; set;} 
    public string Content { get; set;} = string.Empty;
    public DateTime CreatedOn { get; set;} = DateTime.Now;
    public int PostId { get; set;}
    public Post? Post { get; set;}
    public string AppUserId { get; set;} = string.Empty;
    public AppUser? AppUser { get; set;} 

}