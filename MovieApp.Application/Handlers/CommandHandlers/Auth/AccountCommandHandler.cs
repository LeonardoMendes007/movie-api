using AutoMapper;
using MediatR;
using MovieApp.Application.Commands.Auth;
using MovieApp.Application.Responses.Auth;
using MovieApp.Domain.Dtos.Account;
using MovieApp.Domain.Interfaces.Repository;

namespace MovieApp.Application.Handlers.CommandHandlers.Auth;
public class AccountCommandHandler : IRequestHandler<CreateAccountCommand, CredentialsResponse>
{
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;

    public AccountCommandHandler(IAuthRepository authRepository, IMapper mapper)
    {
        _authRepository = authRepository;
        _mapper = mapper;
    }

    public async Task<CredentialsResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {

        var createUserDto = _mapper.Map<CreateAccountDto>(request);

        var appUser = await _authRepository.RegisterAsync(createUserDto, request.Password);

        return _mapper.Map<CredentialsResponse>(appUser);

    }
}
