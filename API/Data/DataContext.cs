using System.Security.Cryptography;
using System.Text;
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
        using var hmac = new HMACSHA512();
        
        modelBuilder.Entity<AppUser>().HasData(
        new AppUser()
        {
            Id = 1,
            Username = "goran",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("goran")),
            PasswordSalt = hmac.Key
        },
        new AppUser()
        {
            Id = 2,
            Username = "liam",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("liam")),
            PasswordSalt = hmac.Key
        },
        new AppUser()
        {
            Id = 3,
            Username = "tijana",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("tijana")),
            PasswordSalt = hmac.Key
        });
    }
}