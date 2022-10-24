using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Services.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/accounts")]
public class AccountsController : BaseController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountsController(DataContext context, ITokenService tokenService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto request)
    {
        // FIXME: this does not work, use a creation DTO
        if (await UserExists(request.Username))
        {
            return BadRequest("Username is taken.");
        }

        using var hmac = new HMACSHA512();

        var user = new AppUser()
        {
            Username = request.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
            PasswordSalt = hmac.Key
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        var token = _tokenService.CreateToken(user);

        var response = new UserDto
        {
            Username = user.Username,
            Token = token
        };

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user is null)
        {
            return Unauthorized("Invalid username and password combination.");
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
        for (var i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("Invalid username and password combination.");
            }
        }

        var token = _tokenService.CreateToken(user);

        var response = new UserDto
        {
            Username = user.Username,
            Token = token
        };

        return Ok(response);
    }

    private async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username.ToLower());
    }
}