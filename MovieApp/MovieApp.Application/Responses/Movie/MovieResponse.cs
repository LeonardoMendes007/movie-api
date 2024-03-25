using MovieApp.Application.Responses.Genre;
using MovieApp.Domain.Entities;

namespace MovieApp.Application.Responses.Movie;
public class MovieResponse 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Views { get; set; }
    public IEnumerable<GenreResponse> Genries { get; set; }
}
