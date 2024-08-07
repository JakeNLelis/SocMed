using System.ComponentModel.DataAnnotations;

namespace backend.Dtos.Account;

public class RegisterDto
{
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name fields can only contain letters.")]
    public string FirstName { get; set; } = string.Empty;
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name fields can only contain letters.")]
    public string? MiddleName { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name fields can only contain letters.")]
    public string LastName { get; set; } = string.Empty;
    public string? ProfilePhoto { get; set; } = null;
    [Required]
    [MaxLength(30, ErrorMessage = "Username can not exceed 30 characters.")]
    public DateTime? Birthdate { get; set; } = null;
    public string UserName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}