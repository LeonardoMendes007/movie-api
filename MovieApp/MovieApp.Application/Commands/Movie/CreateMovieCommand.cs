﻿using MediatR;
using MovieApp.Application.Responses.Movie;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Commands.Movie;
public class CreateMovieCommand : IRequest<MovieResponse>
{
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public DateTime ReleaseDate { get; set; }
    public IEnumerable<Guid> Genries { get; set; }
}
