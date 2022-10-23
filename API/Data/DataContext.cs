using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DbSet<AppUser> Users { get; set; } = null!;
    
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasData(
        new AppUser()
        {
            Id = 1,
            Username = "goran"
        },
        new AppUser()
        {
            Id = 2,
            Username = "liam"
        },
        new AppUser()
        {
            Id = 3,
            Username = "tijana"
        });
    }
}