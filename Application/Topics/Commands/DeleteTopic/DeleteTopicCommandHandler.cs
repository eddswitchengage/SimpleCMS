using MediatR;
using SimpleCMS.Application.Common.Exceptions;
using SimpleCMS.Application.Common.Interfaces;
using SimpleCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Commands.DeleteTopic
{
    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand>
    {
        private readonly ISimpleDbContext _context;

        public DeleteTopicCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            Topic topic = await _context.Topics.FindAsync(request.Id);

            if (topic == null) throw new EntityNotFoundException(nameof(Topic), request.Id);

            _context.Topics.Remove(topic);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
