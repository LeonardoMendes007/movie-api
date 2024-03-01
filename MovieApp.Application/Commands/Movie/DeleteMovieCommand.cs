using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Commands.Movie;
public class DeleteMovieCommand : IRequest
{
    public Guid Id { get; set; }
}
