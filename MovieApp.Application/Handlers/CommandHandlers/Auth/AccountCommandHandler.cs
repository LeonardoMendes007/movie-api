using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MovieApp.Application.Commands.Auth;
using MovieApp.Application.Responses.Auth;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repository;

namespace MovieApp.Application.Handlers.CommandHandlers.Auth;
public class AccountCommandHandler : IRequestHandler<CreateAccountCommand, CredentialsResponse>,
                                     IRequestHandler<SignInAccountCommand, CredentialsResponse>
{
    private readonly ILogger<AccountCommandHandler> _logger;
    private readonly IAuthRepository _authRepository;

    public AccountCommandHandler(ILogger<AccountCommandHandler> logger, IAuthRepository authRepository)
    {
        _logger = logger;
        _authRepository = authRepository;
    }

    public async Task<CredentialsResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var resquestAppUser = new ApplicationUser()
        {
            UserName = request.UserName,
            Email = request.Email,
            EmailConfirmed = true
        };

        var appUser = await _authRepository.RegisterAsync(resquestAppUser, request.Password);

        if (appUser is null)
            return null;

        return new CredentialsResponse()
        {
            Id = Guid.Parse(appUser.Id),
            UserName = appUser.UserName,
            Email = appUser.Email
        };
        
    }

    public async Task<CredentialsResponse> Handle(SignInAccountCommand request, CancellationToken cancellationToken)
    {
        
        var appUser = await _authRepository.SignInAsync(request.UserName, request.Password);

        if (appUser is null)
            throw new UnauthorizedAccessException();

        return new CredentialsResponse()
        {
            Id = Guid.Parse(appUser.Id),
            UserName = appUser.UserName,
            Email = appUser.Email
        }; 
        
    }
}
