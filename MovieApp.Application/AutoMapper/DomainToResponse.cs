using AutoMapper;
using MovieApp.Application.Responses.Auth;
using MovieApp.Domain.Dtos.Credentials;

namespace MovieApp.Application.AutoMapper;
public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        #region CredentialsDto to CredentialsResponse

        CreateMap<CredentialsDto, CredentialsResponse>();

        #endregion
    }
}
