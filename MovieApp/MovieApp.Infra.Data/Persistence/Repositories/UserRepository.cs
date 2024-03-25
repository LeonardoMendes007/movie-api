using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly MovieAppDbContext _movieAppDbContext;
    private readonly DbSet<User> _dbSet;
    public UserRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSet = _movieAppDbContext.Set<User>();
    }

    public async Task<IEnumerable<Movie>> FindFavoritesMovies(Guid id, Expression<Func<Movie, bool>> filter = null, int skip = 0, int take = 30)
    {
        return await _dbSet.Where(x => x.Id == id).Include(x => x.FavoritesMovies).SelectMany(x => x.FavoritesMovies).Where(filter).Take(take).Skip(skip).AsNoTracking().ToListAsync();
    }

    public async Task<User> FindByIdAsync(Guid id)
    {
        var applicationuser = await _dbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (applicationuser is null)
        {
            throw new ResourceNotFoundException();
        }
        return applicationuser;
    }

    public async Task SaveAsync(User user)
    {
        await _dbSet.AddAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        _dbSet.Update(user);
    }
    public async Task RemoveAsync(Guid id)
    {
        var movie = await _dbSet.FindAsync(id);
        if (movie is null)
        {
            throw new ResourceNotFoundException();
        }

        _dbSet.Remove(movie);
    }

    public async Task CommitAsync()
    {
        await _movieAppDbContext.SaveChangesAsync();
    }
}
