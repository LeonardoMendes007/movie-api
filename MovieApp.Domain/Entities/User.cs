using MovieApp.Domain.Entities.@base;

namespace MovieApp.Domain.Entities;
public class User : Entity
{
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IEnumerable<Movie> MovieRatings { get; set; }
    public IEnumerable<Movie> FavoritesMovies { get; set; }
    public IEnumerable<Rating> RatingMovies { get; set; }
}
