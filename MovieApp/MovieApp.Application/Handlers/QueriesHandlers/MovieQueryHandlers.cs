using AutoMapper;
using MediatR;
using MovieApp.Application.Queries.Movie;
using MovieApp.Application.Queries.User;
using MovieApp.Application.Responses.Movie;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repository;
using System.Linq.Expressions;

namespace MovieApp.Application.Handlers.QueriesHandlers;
public class MovieQueryHandlers : IRequestHandler<GetMovieByIdQuery, MovieResponse>,
                                  IRequestHandler<GetMoviesQuery, IEnumerable<MovieResponse>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieQueryHandlers(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.FindByIdAsync(request.Id);

        if (movie is null)
        {
            throw new ResourceNotFoundException();
        }

        movie.Views = movie.Views++;

        await _movieRepository.UpdateAsync(movie);

        return _mapper.Map<MovieResponse>(movie);
    }
    public async Task<IEnumerable<MovieResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Movie, bool>> filter = (x) => x.Name.Contains(request.SearchTerm);

        var movies = _mapper.Map<List<MovieResponse>>(await _movieRepository.FindAllAsync(filter, request.Skip, request.Take));

        return movies;
    }
}
