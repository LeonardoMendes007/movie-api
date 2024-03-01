using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities;
public class Movie : Entity
{
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Views { get; set; }
    public DateTime CreatedDate { get; set;} = DateTime.Now;
    public DateTime UpdatedDate { get; set;}
    public IEnumerable<Rating> Ratings { get; set; }
    public IEnumerable<User> FavoritesUsers { get; set; }
    public IEnumerable<Genre> Genries { get; set; }
}
