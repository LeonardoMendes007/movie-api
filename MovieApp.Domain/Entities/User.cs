using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities;
public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public IEnumerable<Movie> FavoritesMovies { get; set; }
    public IEnumerable<Movie> RateMovies { get; set; }
}
