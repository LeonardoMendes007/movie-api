using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Identity.Identity;
using MovieApp.Infra.Identity.Persistence;
using MovieApp.Infra.Identity.Persistence.Repositories;

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

    }
}
