using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>{
        public UpdateBookCommandValidator()
        {

            RuleFor(command=>command.updateBookModel.Genre).MinimumLength(2);
            RuleFor(command=>command.updateBookModel.PageCount).GreaterThan(0);
            RuleFor(command=>command.BookId).GreaterThan(0);            
        }
    }
}