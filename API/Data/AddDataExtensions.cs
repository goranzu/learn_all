using Microsoft.EntityFrameworkCore;

namespace API.Data;

public static class AddDataExtensions
{
   public static IServiceCollection AddData(this IServiceCollection services)
   {
      services.AddDbContext<DataContext>(options =>
      {
         options.UseSqlite();
      });
      return services;
   }
}