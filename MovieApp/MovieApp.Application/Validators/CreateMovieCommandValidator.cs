using FluentValidation;
using MovieApp.Application.Commands.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Validators;
public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator() {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Synopsis).NotEmpty(); 
        RuleFor(x => x.ReleaseDate).NotEmpty();
        RuleFor(x => x.Genries).Must(x => x.Any());
    }
}
