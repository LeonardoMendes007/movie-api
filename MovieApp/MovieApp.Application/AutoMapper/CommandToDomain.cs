using AutoMapper;
using MovieApp.Application.Commands.Movie;
using MovieApp.Application.Responses.Genre;
using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;
using MovieApp.Domain.Entities;

namespace MovieApp.Application.AutoMapper;
public class CommandToDomain : Profile
{
    public CommandToDomain()
    {
        #region CreateMovieCommand to Movie

        CreateMap<CreateMovieCommand, Movie>()
            .ForMember(dest => dest.Genries, opt => opt.Ignore());

        #endregion

        #region UpdateMovieCommand to Movie

        CreateMap<UpdateMovieCommand, Movie>();

        #endregion

        #region Genre to GenreResponse

        CreateMap<Genre, GenreResponse>();

        #endregion

    }
}
