using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Topics.Commands.UpsertTopic
{
    public class UpsertTopicCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
