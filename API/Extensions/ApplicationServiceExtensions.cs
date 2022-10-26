using API.Data;
using API.Data.Repositories;
using API.Profiles;
using API.Services.Tokens;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<ITokenService, TokenService>();
        services.AddDbContext<DataContext>(options => { options.UseSqlite(config.GetConnectionString("Default")); });
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(
            typeof(AutoMapperProfiles).Assembly);
        return services;
    }
}