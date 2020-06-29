using MediatR;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand>
    {
        private readonly ISimpleDbContext _context;

        public DeleteContentCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            Content content = await _context.Contents.FindAsync(request.Id);

            if (content == null)
                throw new NotFoundException(nameof(content), request.Id);

            _context.Contents.Remove(content);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
