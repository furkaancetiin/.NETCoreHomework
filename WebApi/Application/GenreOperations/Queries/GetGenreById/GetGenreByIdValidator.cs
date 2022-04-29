using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreById{
    public class GetGenreByIdValidator:AbstractValidator<GetGenreById>{
        public GetGenreByIdValidator()
        {
            RuleFor(g=>g.GenreId).GreaterThan(0);
        }
    }
}