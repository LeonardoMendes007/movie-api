using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Extensions;
using MovieApp.Application.Commands.Movie;
using MovieApp.Application.Queries.Movie;
using MovieApp.Application.Queries.User;
using MovieApp.Application.Responses.Movie;

namespace MovieApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<MovieController> _logger;

    public MovieController(IMediator mediator, ILogger<MovieController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie([FromRoute] Guid id)
    {
        var movie = await _mediator.Send(new GetMovieByIdQuery(id));

        return Ok(this.ResponseBase<MovieResponse>(movie, System.Net.HttpStatusCode.OK));
    }

    [HttpGet]
    public async Task<IActionResult> GetMoveis([FromQuery] Guid genreId, [FromQuery] string searchTerm = "", [FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var getMoviesQuery = new GetMoviesQuery()
        {
            GenreId = genreId,
            SearchTerm = searchTerm,
            Take = take,
            Skip = skip
        };

        var movies = await _mediator.Send(getMoviesQuery);

        return Ok(this.ResponseBase<IEnumerable<MovieResponse>>(movies, System.Net.HttpStatusCode.OK));
    }

    [HttpPost()]
    public async Task<IActionResult> GetMovie([FromBody] CreateMovieCommand createMovieCommand)
    {
        var movieResponse = await _mediator.Send(createMovieCommand);

        return Created($"api/Movie/{movieResponse.Id}", this.ResponseBase<MovieResponse>(movieResponse, System.Net.HttpStatusCode.Created));
    }

}
