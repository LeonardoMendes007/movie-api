using AutoMapper;
using MediatR;
using MovieApp.Application.Queries.User;
using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repositories;
using MovieApp.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class UserQueryHandlers : IRequestHandler<GetUserByIdQuery, UserResponse>,
                                 IRequestHandler<GetUserFavoriteMoviesQuery, IEnumerable<MovieResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserQueryHandlers(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<UserResponse>(await _unitOfWork.UserRepository.FindByIdAsync(request.Id));
    }

    public async Task<IEnumerable<MovieResponse>> Handle(GetUserFavoriteMoviesQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Movie, bool>> filter = x => x.Name.Contains(request.SearchTerm);

        var favoriteMovies = _mapper.Map<List<MovieResponse>>(await _unitOfWork.UserRepository.FindFavoritesMovies(request.Id, filter, request.Skip, request.Take));

        return favoriteMovies;
    }
}
