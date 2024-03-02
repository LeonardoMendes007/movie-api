using MovieApp.Domain.Entities;
using System.Linq.Expressions;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IMovieRepository 
{
    Task<IEnumerable<Movie>> FindAllAsync(Expression<Func<Movie, bool>> filter = null, int skip = 0, int take = 30);
    Task<IEnumerable<Rating>> FindRatingsById(Guid id, Expression<Func<Rating, bool>> filter = null, int skip = 0, int take = 30);
    Task<Movie> FindByIdAsync(Guid id);
    Task SaveAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task RemoveAsync(Guid id);
    Task CommitAsync();
}
