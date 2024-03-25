using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces.Repositories;
using MovieApp.Domain.Interfaces.Repository;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private IUserRepository _userRepository;
    private IMovieRepository _movieRepository;
    private IRatingRepository _ratingRepository;
    private IGenreRepository _genreRepository;

    private readonly MovieAppDbContext _movieAppDbContext;

    public UnitOfWork(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepository = _userRepository ?? new UserRepository(_movieAppDbContext);
        }
    }

    public IMovieRepository MovieRepository
    {
        get
        {
            return _movieRepository = _movieRepository ?? new MovieRepository(_movieAppDbContext);
        }
    }

    public IRatingRepository RatingRepository
    {
        get
        {
            return _ratingRepository = _ratingRepository ?? new RatingRepository(_movieAppDbContext);
        }
    }

    public IGenreRepository GenreRepository
    {
        get
        {
            return _genreRepository = _genreRepository ?? new GenreRepository(_movieAppDbContext);
        }
    }

    public async Task CommitAsync()
    {
        await _movieAppDbContext.SaveChangesAsync();
    }

    public void Dispose() {
        _movieAppDbContext.Dispose();
    }
}
