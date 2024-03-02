using MovieApp.Domain.Entities;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IRatingRepository
{
    Task SaveAsync(Rating Rating);
    Task UpdateAsync(Rating Rating);
    Task RemoveAsync(Guid id);
    Task CommitAsync();
}
