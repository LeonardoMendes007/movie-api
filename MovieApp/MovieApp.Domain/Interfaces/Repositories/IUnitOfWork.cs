using MovieApp.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Interfaces.Repositories;
public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IMovieRepository MovieRepository { get; }
    IRatingRepository RatingRepository { get; }
    IGenreRepository GenreRepository { get; }
    Task CommitAsync();
}
