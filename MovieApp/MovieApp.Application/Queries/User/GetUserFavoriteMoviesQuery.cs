using MediatR;
using MovieApp.Application.Responses.Movie;

namespace MovieApp.Application.Queries.User;
public class GetUserFavoriteMoviesQuery : IRequest<IEnumerable<MovieResponse>>
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public string? SearchTerm { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}
