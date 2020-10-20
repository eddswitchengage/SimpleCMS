using FluentValidation;

namespace SimpleCMS.Application.Categories.Commands.UpsertCategory
{
    public class UpsertCategoryCommandValidator : AbstractValidator<UpsertCategoryCommand>
    {
        public UpsertCategoryCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty().MaximumLength(24);
        }
    }
}
