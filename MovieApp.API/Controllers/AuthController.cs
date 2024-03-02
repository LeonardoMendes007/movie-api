using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Commands.Auth;

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
        var resp = await _mediator.Send(registerAccountCommand);

        if (resp is null)
            return BadRequest();

        return Ok(resp);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] SignInAccountCommand signInAccountCommand)
    {
        var resp = await _mediator.Send(signInAccountCommand);

        if (resp is null)
            return Unauthorized();

        return Ok(resp);
    }

}
