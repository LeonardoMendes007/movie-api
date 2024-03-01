using MediatR;
using MovieApp.Application.Responses.User;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Commands.User;
public class CreateUserCommand : IRequest<UserResponse>
{
    public string UserName { get; set; }
    public string Email { get; set; }
}
