using AutoMapper;
using MovieApp.Application.Commands.Auth;
using MovieApp.Domain.Dtos.Account;
namespace MovieApp.Application.AutoMapper;
public class CommandToDomain : Profile
{
    public CommandToDomain()
    {
        #region CreateAccountCommand to CreateAccountDto

        CreateMap<CreateAccountCommand, CreateAccountDto>();

        #endregion


    }
}
