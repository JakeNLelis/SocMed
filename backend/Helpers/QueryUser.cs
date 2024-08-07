namespace backend.Helpers;

public class QueryUser
{
    public string? FullName { get; set; } = null;
    public string? UserName { get; set; } = null;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set;} = 10;
}