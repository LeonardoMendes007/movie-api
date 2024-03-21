﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Extensions;
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
        var user = await _mediator.Send(new GetMovieByIdQuery(id));

        return Ok(this.ResponseBaseFactory(user, System.Net.HttpStatusCode.OK));
    }

    [HttpGet]
    public async Task<IActionResult> GetMoveis([FromRoute] Guid id, Guid genreId, string searchTerm = "", int skip = 0, int take = 30)
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
