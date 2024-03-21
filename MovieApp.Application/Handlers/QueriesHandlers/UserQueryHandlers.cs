using AutoMapper;
using MediatR;
using MovieApp.Application.Queries.User;
using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class UserQueryHandlers : IRequestHandler<GetUserByIdQuery, UserResponse>,
                                 IRequestHandler<GetUserFavoritesQuery, List<MovieResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserQueryHandlers(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<UserResponse>(await _userRepository.FindByIdAsync(request.Id));
    }

    public async Task<List<MovieResponse>> Handle(GetUserFavoritesQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Movie, bool>> filter = x => x.Name.Contains(request.SearchTerm);

        var algo = await _userRepository.FindFavoritesMovies(request.Id, filter, request.Skip, request.Take);

        var algo2 = _mapper.Map<List<MovieResponse>>(algo);

        return algo2;
    }
}
