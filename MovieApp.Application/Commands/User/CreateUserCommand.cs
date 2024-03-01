using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Commands.User;
public class CreateUserCommand : IRequest
{
    public string UserName { get; set; }
    public string Email { get; set; }
}
