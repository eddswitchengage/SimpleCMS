using FluentValidation;

namespace SimpleCMS.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandValidator : AbstractValidator<DeleteContentCommand>
    {
        public DeleteContentCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
