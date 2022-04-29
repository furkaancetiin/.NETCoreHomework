using System;
using FluentValidation;


namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>{
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a=>a.AuthorId).GreaterThan(0);
            RuleFor(a=>a.Model.FirstName).NotEmpty();
            RuleFor(a=>a.Model.FirstName).MinimumLength(2);
            RuleFor(a=>a.Model.LastName).NotEmpty();
            RuleFor(a=>a.Model.FirstName).MinimumLength(2);
            RuleFor(a=>a.Model.DateOfBirth).NotEmpty();
            RuleFor(a=>Convert.ToDateTime(a.Model.DateOfBirth)).LessThan(DateTime.Now.Date).WithMessage("Doğum tarihi bugünün tarihine eşit ya da bu tarihten büyük olamaz.");
        }
    }
}