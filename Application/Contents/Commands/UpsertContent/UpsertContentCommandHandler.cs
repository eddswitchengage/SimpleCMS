using MediatR;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Content content;

            if (request.Id.HasValue)
            {
                content = await _context.Contents.FindAsync(request.Id.Value);
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
