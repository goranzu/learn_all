using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/accounts")]
public class AccountsController : BaseController
{
    private readonly DataContext _context;

    public AccountsController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(string username,
        string password)
    {
        // FIXME: this does not work, use a creation DTO
        using var hmac = new HMACSHA512();

        var user = new AppUser()
        {
            Username = username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();


        return Ok(user);
    }
}