using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Model;
using MovieApp.API.Response;
using MovieApp.Infra.Identity.Interfaces.Services;
using MovieApp.Infra.Identity.Model;
using System.Net;

namespace MovieApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        var result = await _authService.RegisterAccount(registerModel.UserName, registerModel.Email, registerModel.Password);

        if (result.IsAuthenticated)
            return Ok(new ResponseBase<AuthResult>(result, HttpStatusCode.OK));

        return Unauthorized(new ResponseBase<AuthResult>(result, HttpStatusCode.Unauthorized));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
    {
        var result = await _authService.SignInAsync(signInModel.Email, signInModel.Password);

        if (result.IsAuthenticated)
            return Ok(new ResponseBase<AuthResult>(result, HttpStatusCode.OK));

        return Unauthorized(new ResponseBase<AuthResult>(result, HttpStatusCode.Unauthorized));
    }

}
