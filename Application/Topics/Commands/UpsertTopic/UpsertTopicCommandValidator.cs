using FluentValidation;

namespace SimpleCMS.Application.Topics.Commands.UpsertTopic
{
    public class UpsertTopicCommandValidator : AbstractValidator<UpsertTopicCommand>
    {
        public UpsertTopicCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty();
            RuleFor(v => v.CategoryId).NotEmpty();
        }
    }
}
