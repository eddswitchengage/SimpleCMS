using MediatR;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

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

            if (category == null) throw new EntityNotFoundException(nameof(Category), request.Id);

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
