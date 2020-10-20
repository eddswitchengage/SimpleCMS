using FluentValidation;

namespace SimpleCMS.Application.Contents.Commands.UpsertContent
{
    public class UpsertContentCommandValidator : AbstractValidator<UpsertContentCommand>
    {
        public UpsertContentCommandValidator()
        {
            RuleFor(v => v.TopicId).NotEmpty();
            RuleFor(v => v.Title).NotEmpty();
        }
    }
}
