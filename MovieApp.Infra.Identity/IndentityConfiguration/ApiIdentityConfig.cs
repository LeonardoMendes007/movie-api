using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Infra.Identity.Identity;
using MovieApp.Infra.Identity.Interfaces.Services;
using MovieApp.Infra.Identity.Persistence;
using MovieApp.Infra.Identity.Services;

namespace MovieApp.Infra.CrossCutting.Identity.IndentityConfiguration;
public static class ApiIdentityConfig
{
    public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

        services.AddIdentityCore<ApplicationUser>()
         .AddEntityFrameworkStores<ApplicationDbContext>();

        services.Configure<IdentityOptions>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.User.RequireUniqueEmail = true;
        });

        #region Service
        services.AddScoped<IAuthService, AuthService>();
        #endregion

    }
}
