using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Response;
using MovieApp.Application.Commands.Auth;
using MovieApp.Application.Responses.Auth;
using System.Net;

namespace MovieApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IMediator mediator, ILogger<AuthController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Register([FromBody] CreateAccountCommand registerAccountCommand)
    {
        var result = await _mediator.Send(registerAccountCommand);

        if (result is null)
            return BadRequest();

        return Ok(new ResponseBase<CredentialsResponse>(result, HttpStatusCode.OK));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] SignInAccountCommand signInAccountCommand)
    {
        var result = await _mediator.Send(signInAccountCommand);

        if (result is null)
            return Unauthorized();

        return Ok(new ResponseBase<CredentialsResponse>(result, HttpStatusCode.OK));
    }

}
