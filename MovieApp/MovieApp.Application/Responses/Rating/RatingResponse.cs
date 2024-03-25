using MovieApp.Application.Responses.Movie;

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
