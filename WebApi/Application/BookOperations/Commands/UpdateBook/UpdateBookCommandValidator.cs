using System;
using FluentValidation;

namespace WebApi.Application.Commands.UpdateBook{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>{
        public UpdateBookCommandValidator()
        {           
            RuleFor(command=>command.updateBookModel.PageCount).GreaterThan(0);
            RuleFor(command=>command.BookId).GreaterThan(0);            
        }
    }
}