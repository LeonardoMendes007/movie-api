using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repositories;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class GenreRepository : IGenreRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<Genre> _dbSetGenre;

    public GenreRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSetGenre = movieAppDbContext.Genres;
    }

    public async Task<IEnumerable<Genre>> FindAllAsync()
    {
        return await _dbSetGenre.ToListAsync();
    }

    public async Task<Genre> FindByIdAsync(Guid id)
    {
        return await _dbSetGenre.Where(x => x.Id == id).FirstAsync();
    }
}
