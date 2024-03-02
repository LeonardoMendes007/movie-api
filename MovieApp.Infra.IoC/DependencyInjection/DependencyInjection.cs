using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Infra.Data.Persistence;
using MovieApp.Infra.IoC.AutoMapperConfig;
using MovieApp.Infra.CrossCutting.Identity.IndentityConfiguration;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Data.Persistence.Repositories;

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

        #region Identity
        services.AddApiIdentityConfiguration(configuration);
        #endregion

        #region MediatR
        var assembly = AppDomain.CurrentDomain.Load("MovieApp.Application");

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        #endregion

        #region AutoMapper
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        #endregion


        #region Repository
        services.AddScoped<IAuthRepository, AuthRepository>();
        #endregion

        return services;
    }
}
