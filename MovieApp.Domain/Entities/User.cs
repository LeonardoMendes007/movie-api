using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities;
public class User : Entity
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IEnumerable<Movie> FavoritesMovies { get; set; }
    public IEnumerable<Rating> RatingMovies { get; set; }
}
