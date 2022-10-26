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

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     using var hmac = new HMACSHA512();
    //
    //     modelBuilder.Entity<AppUser>().HasData(
    //         new AppUser(
    //             "goran",
    //             hmac.ComputeHash(Encoding.UTF8.GetBytes("goran")),
    //             hmac.Key,
    //             "m")
    //         {
    //             Id = 1,
    //         },
    //         new AppUser(
    //             "liam",
    //             hmac.ComputeHash(Encoding.UTF8.GetBytes("liam")),
    //             hmac.Key,
    //             "m")
    //         {
    //             Id = 2,
    //         },
    //         new AppUser(
    //             "tijana",
    //             hmac.ComputeHash(Encoding.UTF8.GetBytes("tijana")),
    //             hmac.Key,
    //             "v")
    //         {
    //             Id = 3,
    //         });
    // }
}