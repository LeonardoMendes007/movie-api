using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Extensions;
using MovieApp.Application.Queries.User;
using MovieApp.Application.Responses.Movie;
using MovieApp.Application.Responses.User;

namespace MovieApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(this.ResponseBaseFactory(user, System.Net.HttpStatusCode.OK));
    }

    [HttpGet("{id}/favorites")]
    public async Task<IActionResult> GetFavorites([FromRoute] Guid id, Guid genreId, string searchTerm = "", int skip = 0, int take = 30)
    {
        var getUserFavoritesQuery = new GetUserFavoritesQuery()
        {
            Id = id,
            GenreId = genreId,
            SearchTerm = searchTerm,
            Take = take,
            Skip = skip
        };

        var movies = await _mediator.Send(getUserFavoritesQuery);

        return Ok(this.ResponseBaseFactory(movies, System.Net.HttpStatusCode.OK));
    }
}
