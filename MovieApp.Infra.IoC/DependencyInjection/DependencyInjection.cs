﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Infra.Data.Persistence;
using MovieApp.Infra.CrossCutting.Identity.IndentityConfiguration;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Identity.Persistence.Repositories;
using MovieApp.Application.AutoMapper;
using MovieApp.Application.AutoMapper.AutoMapperConfig;

namespace MovieApp.Infra.IoC.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        #region Banco de dados
        services.AddDbContext<MovieAppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));
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
