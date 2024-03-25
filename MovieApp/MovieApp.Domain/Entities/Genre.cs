using MovieApp.Domain.Entities.@base;

namespace MovieApp.Domain.Entities;
public class Genre : Entity
{
    public string Name { get; set; }
    public IEnumerable<Movie> Movies { get; set; }
}
