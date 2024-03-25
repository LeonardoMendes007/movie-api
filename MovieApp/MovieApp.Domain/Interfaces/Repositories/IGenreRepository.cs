using MovieApp.Domain.Entities;
using System.Collections.Generic;

namespace MovieApp.Domain.Interfaces.Repositories;
public interface IGenreRepository
{
    Task<IEnumerable<Genre>> FindAllAsync();
    Task<Genre> FindByIdAsync(Guid id);
}
