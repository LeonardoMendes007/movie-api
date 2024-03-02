using MediatR;
using MovieApp.Application.Commands.Auth;
using MovieApp.Application.Responses.Auth;
using MovieApp.Domain.Dtos;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repository;

namespace MovieApp.Application.Handlers.CommandHandlers.Auth;
public class AccountCommandHandler : IRequestHandler<CreateAccountCommand, CredentialsResponse>
{
    private readonly IAuthRepository _authRepository;

    public AccountCommandHandler(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<CredentialsResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var createUserDto = new CreateUserDto()
        {
            UserName = request.UserName,
            Email = request.Email
        };

        var appUser = await _authRepository.RegisterAsync(createUserDto, request.Password);

        Console.WriteLine(appUser);


        return new CredentialsResponse()
        {
            UserName = createUserDto.UserName,
            Email = createUserDto.Email
        };

    }
}
