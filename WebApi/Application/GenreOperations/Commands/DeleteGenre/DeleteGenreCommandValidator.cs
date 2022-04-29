using FluentValidation;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;

namespace WebApi.Application.GenreOperations.Queries.GetGenreById{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>{
        public DeleteGenreCommandValidator()
        {
            RuleFor(g=>g.GenreId).GreaterThan(0);
        }
    }
}