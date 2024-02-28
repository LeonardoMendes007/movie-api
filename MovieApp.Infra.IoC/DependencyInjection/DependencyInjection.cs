using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Infra.Data.Persistence;

namespace MovieApp.Infra.IoC.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        #region Banco de dados
        services.AddDbContext<MovieAppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        #endregion

        #region MediatR
        #endregion

        #region AutoMapper
        #endregion


        #region Repository
        #endregion

        return services;
    }
}
