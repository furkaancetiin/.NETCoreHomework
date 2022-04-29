using FluentValidation;

namespace WebApi.Application.Queries.GetBookById{
    public class GetBookByIdValidator:AbstractValidator<GetBookById>{
        public GetBookByIdValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
            RuleFor(command=>command.BookId).NotEmpty();
        }
    }
}