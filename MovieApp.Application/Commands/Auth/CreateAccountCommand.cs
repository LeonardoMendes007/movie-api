﻿using MediatR;
using MovieApp.Application.Responses.Auth;

namespace MovieApp.Application.Commands.Auth;
public class CreateAccountCommand : IRequest<CredentialsResponse>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
