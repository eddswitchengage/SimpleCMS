using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Application.Contents.Commands.UpsertContent
{
    public class UpsertContentCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public int TopicId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string HTMLBody { get; set; }
        public string Tags { get; set; }
    }
}
