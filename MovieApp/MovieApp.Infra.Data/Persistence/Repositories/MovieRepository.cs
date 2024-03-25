using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using System.Linq;
using System.Linq.Expressions;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class MovieRepository : IMovieRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Movie> _dbSetMovie;
    private readonly DbSet<Rating> _dbSetRating;

    public MovieRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSetMovie = _movieAppDbContext.Set<Movie>();
        _dbSetRating = _movieAppDbContext.Set<Rating>();
    }

    public async Task<IEnumerable<Movie>> FindAllAsync(Expression<Func<Movie, bool>> filter = null, int skip = 0, int take = 30)
    {
        return await _dbSetMovie.Where(filter).Take(take).Skip(skip).Include(x => x.Genries).AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Rating>> FindRatingsById(Guid id, Expression<Func<Rating, bool>> filter = null, int skip = 0, int take = 30)
    {
        return await _dbSetRating.Where(x => x.MovieId == id).Where(filter).Take(take).Skip(skip).Include(x => x.User).AsNoTracking().ToListAsync();
    }

    public async Task<Movie> FindByIdAsync(Guid id)
    {
        var movie = await _dbSetMovie.Where(x => x.Id == id).Include(x => x.Genries).AsNoTracking().FirstOrDefaultAsync();
        return movie;
    }

    public async Task SaveAsync(Movie movie)
    {
        await _dbSetMovie.AddAsync(movie);
    }

    public async Task UpdateAsync(Movie movie)
    {
        _dbSetMovie.Update(movie);
    }
    public async Task RemoveAsync(Guid id)
    {
        var movie = await _dbSetMovie.FindAsync(id);
        if (movie is null)
        {
            throw new ResourceNotFoundException();
        }

        _dbSetMovie.Remove(movie);
    }

}
