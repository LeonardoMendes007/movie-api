using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IUserRepository
{
    Task<User> FindByIdAsync(Guid id); 
    Task<IEnumerable<Movie>> FindFavoritesMovies(Guid id, Expression<Func<Movie, bool>> filter = null, int skip = 0, int take = 30);
    Task SaveAsync(User user);
    Task UpdateAsync(User user);
    Task RemoveAsync(Guid id);
    Task CommitAsync();
}
