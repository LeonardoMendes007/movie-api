using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Models;
using MovieApp.API.Response;
using MovieApp.API.Service;
using MovieApp.Infra.Identity.Interfaces.Services;
using MovieApp.Infra.Identity.Model;
using System.Net;

namespace MovieApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly TokenService _tokenService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(IAuthService authService, ILogger<AccountController> logger, TokenService tokenService)
    {
        _authService = authService;
        _logger = logger;
        _tokenService = tokenService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        var result = await _authService.RegisterAccount(registerModel.UserName, registerModel.Email, registerModel.Password);

        if (!result.IsAuthenticated || result.Credential is null)
            return Unauthorized(new ResponseBase<AuthResult>(result, HttpStatusCode.Unauthorized));

        var tokenModel = _tokenService.GenerateToken(result.Credential);

        return Ok(new ResponseBase<TokenModel>(tokenModel, HttpStatusCode.OK));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
    {
        var result = await _authService.SignInAsync(signInModel.Email, signInModel.Password);

        if (!result.IsAuthenticated || result.Credential is null)
            return Unauthorized(new ResponseBase<AuthResult>(result, HttpStatusCode.Unauthorized));

        var tokenModel = _tokenService.GenerateToken(result.Credential);

        return Ok(new ResponseBase<TokenModel>(tokenModel, HttpStatusCode.OK));
    }

}
