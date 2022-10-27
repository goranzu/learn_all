using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Extensions;

namespace API.Entities;

public sealed class AppUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public byte[] PasswordHash { get; set; } 
    [Required]
    public byte[] PasswordSalt { get; set; }

    public DateTime DateOfBirth { get; set; }
    public string? KnownAs { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastActive { get; set; } = DateTime.Now;
    public string Gender { get; set; }
    public string? Introduction { get; set; } 
    public string? LookingFor { get; set; } 
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public ICollection<Photo>? Photos { get; set; }

#pragma warning disable CS8618
    public AppUser()
#pragma warning restore CS8618
    {
        // nodig voor EF core anders krijg je "no suitable constructor found" error
    }
    
    public AppUser(string username, byte[] passwordHash, byte[] passwordSalt, string gender)
    {
        UserName = username;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Gender = gender;
    }

    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();
    // }
}