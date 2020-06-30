using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace SimpleCMS.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ISimpleDbContext _context;

        public DeleteCategoryCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _context.Categories.FindAsync(request.Id);

            if (category == null) throw new NotFoundException(nameof(Category), request.Id);

            var hasTopics = _context.Topics.Any(t => t.CategoryId == category.CategoryId);
            if (hasTopics)
            {
                throw new DeleteFailureException(nameof(category), request.Id,
                    "Category not empty.");
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
