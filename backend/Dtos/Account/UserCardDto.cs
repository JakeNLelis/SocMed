namespace backend.Dtos.Account;

public class UserCardDto
{
    public string Id { get; set;} = string.Empty;
    public string? ProfilePhoto { get; set; } = null;
    public string FullName { get; set;} = string.Empty;
    public string UserName { get; set;} = string.Empty;
    public string Email { get; set;} = string.Empty;
}