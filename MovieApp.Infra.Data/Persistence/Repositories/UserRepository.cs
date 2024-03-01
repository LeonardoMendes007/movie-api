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
    private readonly DbSet<ApplicationUser> _dbSet;
    public UserRepository(MovieAppDbContext movieAppDbContext)
    {
        _movieAppDbContext = movieAppDbContext;
        _dbSet = _movieAppDbContext.Set<ApplicationUser>();
    }

    public async Task<IEnumerable<Movie>> FindFavoritesMovies(Guid id, Expression<Func<Movie, bool>> filter = null, int skip = 0, int take = 30)
    {
        return await _dbSet.Where(x => x.Id == id.ToString()).Include(x => x.FavoritesMovies).SelectMany(x => x.FavoritesMovies).Where(filter).Take(take).Skip(skip).AsNoTracking().ToListAsync();
    }

    public async Task<ApplicationUser> FindByIdAsync(Guid id)
    {
        var applicationUser = await _dbSet.Where(x => x.Id == id.ToString()).AsNoTracking().FirstOrDefaultAsync();
        if (applicationUser is null)
        {
            throw new ResourceNotFoundException();
        }
        return applicationUser;
    }

    public async Task SaveAsync(ApplicationUser user)
    {
        await _dbSet.AddAsync(user);
    }

    public async Task UpdateAsync(ApplicationUser user)
    {
        await _dbSet.AddAsync(user);
    }
    public async Task RemoveAsync(Guid id)
    {
        var movie = await _dbSet.FindAsync(id);
        if (movie is null)
        {
            throw new ResourceNotFoundException();
        }

        await _dbSet.AddAsync(movie);
    }

    public async Task CommitAsync()
    {
        await _movieAppDbContext.SaveChangesAsync();
    }

    
}
