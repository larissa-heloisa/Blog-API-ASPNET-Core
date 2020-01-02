using Domain.Entities.Post;
using FluentValidation;
using System;

namespace Application.Validation
{
    public class PostValidation : AbstractValidator<Post>
    {
        public PostValidation()
        {
            RuleFor(c => c.Title)
                .NotNull()
                .WithMessage("Title cannot be null")
                .NotEmpty()
                .WithMessage("Title cannot be empty");

            RuleFor(c => c.Description)
                .NotNull()
                .WithMessage("Description cannot be null")
                .NotEmpty()
                .WithMessage("Description cannot be empty");

            RuleFor(c => c.IdPost)
                .Must(Validator)
                .WithMessage("Id cannot be empty")
                .NotNull()
                .WithMessage(" PostId cannot be null");           
        }
        public bool Validator(Guid Id)
        {
            return (Id != Guid.Empty);
        }
    }
}
