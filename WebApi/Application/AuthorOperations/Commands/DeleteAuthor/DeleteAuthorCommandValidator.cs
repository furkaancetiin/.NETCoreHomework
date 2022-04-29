using System;
using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor{
    public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommand>{
        public DeleteAuthorCommandValidator()
        {
            RuleFor(a=>a.AuthorId).GreaterThan(0);
          
        }
    }
}