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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class RatingRepository : IRatingRepository
{
    private readonly MovieAppDbContext _dbContext;
    private readonly DbSet<Rating> _dbSet;

    public RatingRepository(MovieAppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Rating>();
    }

    public async Task SaveAsync(Rating Rating)
    {
        await _dbSet.AddAsync(Rating);
    }

    public async Task UpdateAsync(Rating Rating)
    {
        _dbSet.Update(Rating);
    }
    public async Task RemoveAsync(Guid id)
    {
        var Rating = await _dbSet.FindAsync(id);
        if (Rating is null)
        {
            throw new ResourceNotFoundException();
        }

        _dbSet.Remove(Rating);
    }

    public async Task CommitAsync()
    {
        _dbContext.SaveChanges();
    }
}
