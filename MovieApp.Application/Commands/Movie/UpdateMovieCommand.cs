using MediatR;
using MovieApp.Application.Responses.Movie;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Commands.Movie;
public class UpdateMovieCommand : IRequest<MovieResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public DateTime ReleaseDate { get; set; }
    public IEnumerable<Genre> Genries { get; set; }
}
