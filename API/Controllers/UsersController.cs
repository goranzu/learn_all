using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/users")]
public sealed class UsersController : BaseController
{
    private readonly DataContext _dataContext;

    public UsersController(DataContext dataContext)
    {
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _dataContext.Users
            .ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var user = await _dataContext.Users
            .FindAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}