using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public sealed class RegisterDto
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; } = null!;
}