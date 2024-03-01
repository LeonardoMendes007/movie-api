using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Domain.Entities;
using MovieApp.Infra.Data.Persistence;

namespace MovieApp.Infra.CrossCutting.Identity.IndentityConfiguration;
public static class ApiIdentityConfig
{
    public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityCore<ApplicationUser>()
         .AddEntityFrameworkStores<MovieAppDbContext>();

        services.Configure<IdentityOptions>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.User.RequireUniqueEmail = true;
        });

    }
}
