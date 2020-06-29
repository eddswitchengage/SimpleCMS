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

namespace SimpleCMS.Application.Topics.Commands.UpsertTopic
{
    public class UpsertTopicCommandHandler : IRequestHandler<UpsertTopicCommand, int>
    {
        private readonly ISimpleDbContext _context;

        public UpsertTopicCommandHandler(ISimpleDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpsertTopicCommand request, CancellationToken cancellationToken)
        {
            if ((await _context.Categories.FindAsync(request.CategoryId)) == null)
            {
                throw new BadRequestException($"{nameof(request.CategoryId)} {request.CategoryId} is invalid.");
            }

            Topic topic;

            if (request.Id.HasValue)
            {
                topic = await _context.Topics.FindAsync(request.Id.Value);

                if (topic == null) throw new NotFoundException(nameof(Topic), request.Id);
            }
            else
            {
                topic = new Topic();

                _context.Topics.Add(topic);
            }

            topic.Name = request.Name;
            topic.Description = request.Description;
            topic.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);

            return topic.TopicId;
        }
    }
}
