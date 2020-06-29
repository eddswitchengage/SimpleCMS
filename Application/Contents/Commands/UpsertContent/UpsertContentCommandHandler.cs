using MediatR;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Contents.Commands.UpsertContent
{
    public class UpsertContentCommandHandler : IRequestHandler<UpsertContentCommand, int>
    {
        private readonly ISimpleDbContext _context;

        public UpsertContentCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpsertContentCommand request, CancellationToken cancellationToken)
        {
            if ((await _context.Topics.FindAsync(request.TopicId)) == null)
            {
                throw new BadRequestException($"{nameof(request.TopicId)} {request.TopicId} is invalid.");
            }

            Content content;

            if (request.Id.HasValue)
            {
                content = await _context.Contents.FindAsync(request.Id.Value);

                if (content == null) throw new NotFoundException(nameof(Content), request.Id);
            }
            else
            {
                content = new Content();
                _context.Contents.Add(content);
            }

            content.TopicId = request.TopicId;
            content.Name = request.Name;
            content.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return content.ContentId;
        }
    }
}
