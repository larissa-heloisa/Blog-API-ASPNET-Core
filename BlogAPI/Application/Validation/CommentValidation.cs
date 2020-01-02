using Domain.Entities.Comment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(c => c.Message)
              .NotNull()
              .WithMessage("Message cannot be null")
              .NotEmpty()
              .WithMessage("Message cannot be empty");

            RuleFor(c => c.IdComment)
                .Must(Validator)
                .NotNull()
                .WithMessage("CommentId cannot be null")
                .NotEmpty()
                .WithMessage("CommentId cannot be empty");
        }
        public bool Validator(Guid Id)
        {
            return (Id != Guid.Empty);
        }
    }
}
