using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    private AppUser? _appUser;
    public AppUser AppUser
    {
        set => _appUser = value;
        get => _appUser ?? throw new InvalidOperationException($"Uninitialized property {nameof(AppUser)}");
    }
    // public AppUser AppUser { get; set; }
    // public int AppUserId { get; set; }

#pragma warning disable CS8618
    public Photo()
#pragma warning restore CS8618
    {
    }

    public Photo(string url)
    {
        Url = url;
    }
}