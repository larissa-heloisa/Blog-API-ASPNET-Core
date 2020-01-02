using Domain.Entities.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Name cannot be null")
                .NotEmpty()
                .WithMessage("Name cannot be empty");

            RuleFor(c => c.Login)
                .NotNull()
                .WithMessage("Login cannot be null")
                .NotEmpty()
                .WithMessage("Login cannot be empty");

            RuleFor(c => c.IdUser)
                .Must(Validator)
                .WithMessage("IdUser cannot be empty")
                .NotNull()
                .WithMessage("IdUser cannot be null");
                

            RuleFor(c => c.Email)
                .NotNull()
                .WithMessage("Email cannot be null")
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .EmailAddress()
                .WithMessage("Invalid e-mail format");
        }
        public bool Validator(Guid Id)
        {
            return (Id != Guid.Empty);
        }
    }
}
