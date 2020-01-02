using Domain.Entities.Category;
using FluentValidation;
using System;

namespace Application.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Name cannot be null")
                .NotEmpty()
                .WithMessage("Name cannot be empty");

            RuleFor(c => c.CategoryId)
                .Must(Validator)
                .WithMessage("CategoryId cannot be empty")
                .NotNull()
                .WithMessage("CategoryId cannot be null");
        }
        public bool Validator(Guid Id)
        {
            return (Id != Guid.Empty);
        }
    }
}
