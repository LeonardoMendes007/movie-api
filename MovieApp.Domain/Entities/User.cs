using MovieApp.Domain.Entities.@base;

namespace MovieApp.Domain.Entities;
public class User : Entity
{
    public string Identity { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IEnumerable<Movie> MoviesRating { get; set; }
    public IEnumerable<Movie> FavoritesMovies { get; set; }
    public IEnumerable<Rating> Ratings { get; set; }
}
