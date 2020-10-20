using FluentValidation;

namespace SimpleCMS.Application.Topics.Commands.UpsertTopic
{
    public class UpsertTopicCommandValidator : AbstractValidator<UpsertTopicCommand>
    {
        public UpsertTopicCommandValidator()
        {
            RuleFor(v => v.Title).NotEmpty();
            RuleFor(v => v.CategoryId).NotEmpty();
        }
    }
}
