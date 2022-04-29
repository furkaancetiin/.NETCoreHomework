using FluentValidation;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;

namespace WebApi.Application.GenreOperations.Queries.GetGenreById{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>{
        public UpdateGenreCommandValidator()
        {
            RuleFor(g=>g.GenreId).GreaterThan(0);
        }
    }
}