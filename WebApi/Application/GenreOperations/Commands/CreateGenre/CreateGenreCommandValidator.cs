using FluentValidation;
using WebApi.Application.GenreOperations.Commands.CreateGenre;

namespace WebApi.Application.GenreOperations.Queries.GetGenreById{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>{
        public CreateGenreCommandValidator()
        {
            RuleFor(g=>g.Model.Name).NotEmpty();
        }
    }
}