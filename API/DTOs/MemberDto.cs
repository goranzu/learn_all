using API.Entities;

namespace API.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
    public int Age { get; set; }
    public string? KnownAs { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime LastActive { get; set; }
    public string Gender { get; set; } = null!;
    public string? Introduction { get; set; } 
    public string? LookingFor { get; set; } 
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public ICollection<PhotoDto>? Photos { get; set; }

}