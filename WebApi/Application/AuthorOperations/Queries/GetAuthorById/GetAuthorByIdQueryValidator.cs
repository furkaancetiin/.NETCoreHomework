using System;
using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.Queries.GetAuthorById;

namespace WebApi.Application.AuthorOperations.Commands.GetAuthorById{
    public class GetAuthorByIdQueryValidator:AbstractValidator<GetAuthorByIdQuery>{
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(a=>a.AuthorId).GreaterThan(0);
          
        }
    }
}