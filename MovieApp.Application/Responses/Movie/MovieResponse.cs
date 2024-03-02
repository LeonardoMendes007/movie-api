using MovieApp.Domain.Entities;

namespace MovieApp.Application.Responses.Movie;
public class MovieResponse 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Views { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IEnumerable<Genre> Genries { get; set; }
}
