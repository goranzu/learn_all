using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public sealed class AppUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public byte[] PasswordHash { get; set; } = null!;
    [Required]
    public byte[] PasswordSalt { get; set; } = null!;
}