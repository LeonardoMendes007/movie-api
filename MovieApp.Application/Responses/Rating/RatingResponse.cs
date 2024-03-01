using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Responses.Rating;
public class RatingResponse
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public MovieResponse Movie { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
