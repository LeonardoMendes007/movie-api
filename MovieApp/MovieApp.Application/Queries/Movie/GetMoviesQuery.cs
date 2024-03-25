using MediatR;
using MovieApp.Application.Responses.Movie;

namespace MovieApp.Application.Queries.Movie;
public class GetMoviesQuery : IRequest<IEnumerable<MovieResponse>>
{
    public Guid GenreId { get; set; }
    public string? SearchTerm { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}
