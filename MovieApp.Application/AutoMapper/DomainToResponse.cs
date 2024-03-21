using AutoMapper;
using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;
using MovieApp.Domain.Entities;

namespace MovieApp.Application.AutoMapper;
public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        #region User to UserReponse

        CreateMap<User, UserResponse>();

        #endregion

        #region Movie to MovieReponse

        CreateMap<Movie, MovieResponse>();

        #endregion
    }
}
