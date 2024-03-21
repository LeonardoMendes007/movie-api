using MediatR;
using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;

namespace MovieApp.Application.Queries.User;
public class GetMovieByIdQuery : IRequest<MovieResponse>
{
    public Guid Id { get; set; }

    public GetMovieByIdQuery(Guid id)
    {
        Id = id;
    }
}
