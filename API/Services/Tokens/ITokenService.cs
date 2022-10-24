using API.Entities;

namespace API.Services.Tokens;

public interface ITokenService
{
    string CreateToken(AppUser user);
}