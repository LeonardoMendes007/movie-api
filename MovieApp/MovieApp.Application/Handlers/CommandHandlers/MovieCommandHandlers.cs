using AutoMapper;
using FluentValidation;
using MediatR;
using MovieApp.Application.Commands.Movie;
using MovieApp.Application.Responses.Movie;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Exceptions;
using MovieApp.Domain.Interfaces.Repositories;
using MovieApp.Domain.Interfaces.Repository;

namespace MovieApp.Application.Handlers.CommandHandlers;
public class MovieCommandHandlers : IRequestHandler<CreateMovieCommand, MovieResponse>,
                                    IRequestHandler<UpdateMovieCommand>,
                                    IRequestHandler<DeleteMovieCommand>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IValidator<CreateMovieCommand> _validator;

    public MovieCommandHandlers(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateMovieCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var movie = _mapper.Map<Movie>(request);
        movie.Id = Guid.NewGuid();

        List<Genre> genres = new List<Genre>();

        foreach (var item in request.Genries)
        {
            var genre = await _unitOfWork.GenreRepository.FindByIdAsync(item);

            if(genre == null)
            {
                throw new GenreNotExistsException(item);
            }

            genres.Add(genre);
        }

        movie.Genries = genres;
        await _unitOfWork.MovieRepository.SaveAsync(movie);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<MovieResponse>(await _unitOfWork.MovieRepository.FindByIdAsync(movie.Id));
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movieSaved = await _unitOfWork.MovieRepository.FindByIdAsync(request.Id);

        if (movieSaved is null)
        {
            throw new ResourceNotFoundException(request.Id);
        }

        movieSaved.Name = request.Name;
        movieSaved.Synopsis = request.Synopsis;
        movieSaved.ReleaseDate  = request.ReleaseDate;
        movieSaved.Genries = request.Genries;

        await _unitOfWork.MovieRepository.UpdateAsync(movieSaved);
        await _unitOfWork.CommitAsync();
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movieSaved = await _unitOfWork.MovieRepository.FindByIdAsync(request.Id);

        if (movieSaved is null)
        {
            throw new ResourceNotFoundException(request.Id);
        }

        await _unitOfWork.MovieRepository.RemoveAsync(movieSaved.Id);
        await _unitOfWork.CommitAsync();
    }
}
